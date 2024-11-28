using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demolite.Db.Models;
using Litehome.Db.Enum;

namespace Litehome.Db.Models;

public class Income : AbstractDbItem
{
	[MaxLength(255)]
	public string Name { get; set; } = "";
	
	public decimal Amount { get; set; }
	
	public Frequency Frequency { get; set; }
	
	[MaxLength(50)]
	public required string HomeMemberId { get; set; }
	
	public virtual HomeMember? HomeMember { get; set; }
	
	[NotMapped]
	public decimal MonthlyAmount => Frequency switch
	{
		Frequency.Daily => Amount * 30,
		Frequency.Weekly => Amount * 4,
		Frequency.Monthly => Amount,
		Frequency.Quarterly => Amount / 3,
		Frequency.SemiAnnually => Amount / 6,
		Frequency.Annually => Amount / 12,
		_ => throw new ArgumentOutOfRangeException(),
	};
}