using Litehome.Db.Models.Finance;
using Litehome.Services.Interfaces.Abstract;

namespace Litehome.Services.Interfaces;

public interface IIncomeService : IAbstractItemService<Income>
{
	public decimal MonthlyMemberIncome(HomeMember member);

	public decimal TotalMonthlyIncome { get; }

	public decimal MemberIncomePercentage(HomeMember member);
	
}