using RoomManagement.Models;

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

		public IndexViewModel GetModel()
		{
			this.Expance = _context.Expances.ToList();
			this.Member = _context.Members.ToList();
			return this;
		}

	}
}
