using Microsoft.EntityFrameworkCore;
using RoomManagement.Models;

namespace RoomManagement.ViewModels
{
	public class AdvanceViewModel
	{
		private readonly HappyHomeContext _context;
		public AdvanceViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public List<GetAdvance> GetAdvance { get; set; }
		public List<GetAdvance> Staying { get; set; }
		public List<GetAdvance> vecate { get; set; }

        public int TotalDetected { get; set; }
        public int RemTotalToGive { get; set; }
        public int tovec { get; set; }
		public int TotalReFund { get; set; }

		public int TotalDetected1 { get; set; }
		public int RemTotalToGive1 { get; set; }
        public List<AmountDetail> AmountDetail { get; set; }
		public AdvanceViewModel GetModel()
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetAdvance").ToList();
            this.GetAdvance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetAdvance>>(productTreeString[0].JsonResult);
			this.Staying = this.GetAdvance.Where(x => x.IsVecate == false).ToList();
			this.vecate = this.GetAdvance.Where(x => x.IsVecate == true).ToList();

			this.TotalDetected = this.GetAdvance.Sum(x => x.DetectedAdvAmt).Value;
			this.RemTotalToGive = this.GetAdvance.Sum(x => x.RemAmtFromAd).Value;
			this.TotalReFund = this.GetAdvance.Sum(x => x.AmountReFund).Value;
			this.AmountDetail = _context.AmountDetails.ToList();
			this.TotalDetected1 = this.AmountDetail.First().DetectedAmt.Value;
			this.RemTotalToGive1 = 60000 - this.TotalDetected1;
			this.tovec = this.vecate.Where(x => x.Memberid != 10).Sum(x => x.RemAmtFromAd).Value;

			return this;
		}
    }
}
