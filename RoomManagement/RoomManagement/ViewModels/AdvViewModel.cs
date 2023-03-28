using RoomManagement.Models;

namespace RoomManagement.ViewModels
{
	public class AdvViewModel
	{
		private readonly HappyHomeContext _context;
		public AdvViewModel(HappyHomeContext context)
		{
			_context = context;
		}
		public Expance Expances { get; set; }
		public List<Member> Member { get; set; }

		public AdvViewModel GetModel(int id)
		{
			if(id== 0)
            {
				this.Expances = new Expance();
            }
            else
            {
				this.Expances = _context.Expances.Find(id);

			}
			this.Member = _context.Members.ToList();

			return this;
		}
    }
}
