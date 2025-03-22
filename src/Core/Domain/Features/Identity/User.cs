using Dtat;
using System;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Identity;

public class User(Guid roleId, string username, string password, string emailAddress) : Entity,
	IEntityHasIsActive,
	IEntityHasUpdateDateTime
{
	[Required]
	public Guid RoleId { get; set; } = roleId;

	public virtual Role? Role { get; set; }

	public bool IsActive { get; set; }

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: Constant.MaxLength.Username)]
	public string Username { get; set; } = username;

	[Required(AllowEmptyStrings = false)]
	//[MaxLength(length: Constant.MaxLength.Password)]
	public string Password { get; set; } = password;

	[Required(AllowEmptyStrings = false)]
	//[MaxLength(length: Constant.MaxLength.EmailAddress)]
	public string EmailAddress { get; set; } = emailAddress;

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }
}
