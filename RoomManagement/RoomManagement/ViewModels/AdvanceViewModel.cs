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

        public AdvanceViewModel GetModel()
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetAdvance").ToList();
            this.GetAdvance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetAdvance>>(productTreeString[0].JsonResult);
            return this;
		}
    }
}
