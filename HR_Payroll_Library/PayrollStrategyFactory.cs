using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
	public class PayrollStrategyFactory : IPayrollStrategyFactory
	{
		private readonly APercentBenefit _aPercentBenefit;
	//	private readonly SubtractOperator _subtractOperator;

		public PayrollStrategyFactory(
			APercentBenefit aPercentBenefit)
		{
			_aPercentBenefit = aPercentBenefit;
		}
		
		public IBenefitPackage[] Create() => new IBenefitPackage[] { _aPercentBenefit };
	}
}
