using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demolite.Db.Models;
using Litehome.Db.Enum;

namespace Litehome.Db.Models;

public class Expense : AbstractDbItem
{
	[MaxLength(255)]
	public string Name { get; set; } = "";
	
	public decimal Amount { get; set; }
	
	public Frequency Frequency { get; set; }
	
	public bool IsSavings { get; set; }
	
	public DateTime? Date { get; set; }
	
	[MaxLength(50)]
	public string? ExpenseCategoryId { get; set; }

	public virtual ExpenseCategory? ExpenseCategory { get; set; }

	[MaxLength(50)]
	public string? HomeMemberId { get; set; }
	
	public HomeMember? HomeMember { get; set; }

	[NotMapped]
	public bool IsShared => HomeMemberId is null;
	
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

	[NotMapped]
	public bool HasDate => Frequency is Frequency.Quarterly or Frequency.SemiAnnually or Frequency.Annually;

	public List<DateTime> BookingDates
	{
		get
		{
			var bookingDates = new List<DateTime>();
			
			if (Date is null) 
				return bookingDates;

			switch (Frequency)
			{
				case Frequency.Quarterly:
					bookingDates.Add(Date.Value);
					bookingDates.Add(Date.Value.AddMonths(3));
					bookingDates.Add(Date.Value.AddMonths(6));
					bookingDates.Add(Date.Value.AddMonths(9));
					break;

				case Frequency.SemiAnnually:
					bookingDates.Add(Date.Value);
					bookingDates.Add(Date.Value.AddMonths(6));
					break;
				
				case Frequency.Annually:
					bookingDates.Add(Date.Value);
					break;
			}

			return bookingDates;
		}
	}
}