using Dtat;
using System;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Identity;

public class User : Entity,
	IEntityHasIsActive,
	IEntityHasUpdateDateTime
{
	public User(Guid roleId, string username, string password, string emailAddress) : base()
	{
		RoleId = roleId;
		Username = username;
		Password = password;
		EmailAddress = emailAddress;

		UpdateDateTime = InsertDateTime;
	}

	[Required]
	public Guid RoleId { get; set; }

	public virtual Role? Role { get; set; }

	public bool IsActive { get; set; }

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: Constant.MaxLength.Username)]
	public string Username { get; set; }
	//public string Username { get; init; }

	[Required(AllowEmptyStrings = false)]
	//[MaxLength(length: Constant.MaxLength.Password)]
	public string Password { get; set; }

	[Required(AllowEmptyStrings = false)]
	//[MaxLength(length: Constant.MaxLength.EmailAddress)]
	public string EmailAddress { get; set; }

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }
}
