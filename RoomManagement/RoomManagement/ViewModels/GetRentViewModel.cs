using Microsoft.EntityFrameworkCore;
using RoomManagement.Models;

namespace RoomManagement.ViewModels
{
	public class GetRentViewModel
    {
		private readonly HappyHomeContext _context;
		public GetRentViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public List<GetRent> GetRent { get; set; }
        public int total { get; set; }

        public GetRentViewModel GetModel()
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetRent").ToList();
            this.GetRent = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetRent>>(productTreeString[0].JsonResult);
			this.total = this.GetRent.Sum(x => x.AmountToGive).Value;

			return this;
		}
    }
}
