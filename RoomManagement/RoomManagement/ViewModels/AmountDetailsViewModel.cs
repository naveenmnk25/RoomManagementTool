using RoomManagement.Models;

namespace RoomManagement.ViewModels
{
	public class AmountDetailsViewModel
    {
		private readonly HappyHomeContext _context;
		public AmountDetailsViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public List<AmountDetail> AmountDetail { get; set; }

        public AmountDetailsViewModel GetModel()
		{
            this.AmountDetail = _context.AmountDetails.ToList();
            return this;
		}
    }
}
