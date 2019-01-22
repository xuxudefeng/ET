using MongoDB.Bson.Serialization.Attributes;

namespace ETModel
{
	[ObjectSystem]
	public class PlayerSystem : AwakeSystem<Player, string>
	{
		public override void Awake(Player self, string a)
		{
			self.Awake(a);
		}
	}

	public sealed class Player : Entity
	{
		[Bson]
		public string Account { get; private set; }
		
		public long UnitId { get; set; }

		public void Awake(string account)
		{
			this.Account = account;
		}
		
		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}