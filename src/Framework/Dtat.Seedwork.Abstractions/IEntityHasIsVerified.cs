using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasIsVerified
{
	bool IsVerified { get; }

	Guid? VerifierUserId { get; }

	DateTimeOffset? VerifyDateTime { get; }

	void Verify(Guid verifierUserId);

	void Unverify(Guid verifierUserId);
}
