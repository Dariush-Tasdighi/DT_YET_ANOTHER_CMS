using Dtat;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Dtat.AspNetCore.Mvc.TagHelpers;

public class ModelExpressionConverter : object
{
	public ModelExpressionConverter(ModelExpression modelExpression)
	{
		IsLeftToRight = false;
		HasBeenConverted = false;
		ModelExpression = modelExpression;

		if (modelExpression.ModelExplorer.ModelType.IsEnum)
		{
			ConvertLong();
		}
		else
		{
			switch (modelExpression.ModelExplorer.ModelType)
			{
				case Type typeGuid when typeGuid == typeof(Guid):
				{
					ConvertGuid();
					break;
				}

				case Type typeInt when typeInt == typeof(int):
				case Type typeByte when typeByte == typeof(byte):
				case Type typeLong when typeLong == typeof(long):
				{
					ConvertLong();
					break;
				}

				case Type typeDateTime when typeDateTime == typeof(	DateTimeHelper):
				{
					ConvertDateTime();
					break;
				}

				case Type typeDateTimeOffset when typeDateTimeOffset == typeof(DateTimeOffset):
				case Type typeDateTimeOffsetOrNull when typeDateTimeOffsetOrNull == typeof(DateTimeOffset?):
				{
					ConvertDateTimeOffset();
					break;
				}
			}
		}
	}

	public string? Value { get; protected set; }

	public bool IsLeftToRight { get; protected set; }

	public bool HasBeenConverted { get; protected set; }

	protected ModelExpression ModelExpression { get; init; }

	protected void ConvertGuid()
	{
		object value = ModelExpression.Model;

		IsLeftToRight = true;
		HasBeenConverted = true;

		if (value is null)
		{
			Value = string.Empty;
			return;
		}

		Value = value.ToString();
	}

	protected void ConvertLong()
	{
		object value = ModelExpression.Model;

		IsLeftToRight = true;
		HasBeenConverted = true;

		if (value is null)
		{
			Value = string.Empty;
			return;
		}

		var valueInteget = Convert.ToInt64(value: value);

		var result =
			valueInteget.ToString
			(format: Constant.Format.Integer);

		result = result.ConvertDigitsToUnicode();

		if (result is null)
		{
			Value = string.Empty;
			return;
		}

		Value = result;
	}

	protected void ConvertDateTime()
	{
		object value = ModelExpression.Model;

		IsLeftToRight = true;
		HasBeenConverted = true;

		if (value is null)
		{
			Value = string.Empty;
			return;
		}

		var valueDateTime =
			(System.DateTime)value;

		var result =
			valueDateTime.ToString
			(format: Constant.Format.DateTime);

		result = result.ConvertDigitsToUnicode();

		if (result is null)
		{
			Value = string.Empty;
			return;
		}

		Value = result;
	}

	protected void ConvertDateTimeOffset()
	{
		object value = ModelExpression.Model;

		IsLeftToRight = true;
		HasBeenConverted = true;

		if (value is null)
		{
			Value = string.Empty;
			return;
		}

		var valueDateTime = (DateTimeOffset)value;

		var result =
			valueDateTime.DateTime.ToString(format: Constant.Format.DateTime);

		result = result.ConvertDigitsToUnicode();

		if (result is null)
		{
			Value = string.Empty;
			return;
		}

		Value = result;
	}
}
