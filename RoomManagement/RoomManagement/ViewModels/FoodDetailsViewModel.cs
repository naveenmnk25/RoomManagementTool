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

        public FoodDetailsViewModel GetModel(int? Secid)
		{
            var productTreeString = _context.QueryResult.FromSqlRaw("Execute dbo.GetFootetails {0}", Secid)!.ToList();
            if (productTreeString[0].JsonResult ==null )
            {
                this.FootData = new List<FootData>();
            }
            else
            {
                this.FootData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FootData>>(productTreeString[0].JsonResult);
            }

            return this;
		}
    }
}
