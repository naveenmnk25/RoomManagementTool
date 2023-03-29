using RoomManagement.Models;
using System.Globalization;

namespace RoomManagement.ViewModels
{
	public class IndexViewModel
	{
		private readonly HappyHomeContext _context;
		public IndexViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public List<Expance> Expance { get; set; }
		public List<Member> Member { get; set; }
		public List<FoodDetail> FoodDetail { get; set; }
		public List<RentDetail> RentDetail { get; set; }
		public List<AmountDetail> AmountDetail { get; set; }

		public int totalAmtspend { get; set; }
		public int RemaingAmt { get; set; }
		public int TotalFoodAmount { get; set; }

		public IndexViewModel GetModel()
		{

			this.Expance = _context.Expances.OrderBy(x => x.Date).ToList();
			this.totalAmtspend = _context.Expances.ToList().Where(x=>x.MemberId == 1).Sum(x => x.Price).Value;

			this.TotalFoodAmount = _context.FoodDetails.ToList().Sum(x=> x.AmountRecived).Value;

			this.RemaingAmt = this.TotalFoodAmount - this.totalAmtspend;
			this.FoodDetail = _context.FoodDetails.ToList();
			this.Member = _context.Members.ToList();
            return this;
		}
    }
}
