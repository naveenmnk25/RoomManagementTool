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

        public AdvanceViewModel GetModel()
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetAdvance").ToList();
            this.GetAdvance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetAdvance>>(productTreeString[0].JsonResult);
			this.Staying = this.GetAdvance.Where(x => x.IsVecate == false).ToList();
			this.vecate = this.GetAdvance.Where(x => x.IsVecate == true).ToList();
            return this;
		}
    }
}
