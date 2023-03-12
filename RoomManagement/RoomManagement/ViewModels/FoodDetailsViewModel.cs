using Microsoft.EntityFrameworkCore;
using RoomManagement.Models;

namespace RoomManagement.ViewModels
{
	public class FoodDetailsViewModel
    {
		private readonly HappyHomeContext _context;
		public FoodDetailsViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public List<FootData> FootData { get; set; }

        public FoodDetailsViewModel GetModel()
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetFootetails").ToList();
            this.FootData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FootData>>(productTreeString[0].JsonResult);
            return this;
		}
    }
}
