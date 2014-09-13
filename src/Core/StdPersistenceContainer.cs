
using System;

namespace NetFocus.MagzineSubscribe.CMPServices
{
	public class StdPersistenceContainer  //������һ����׼�ĳ־��������࣬��Ϊ���ࡣ
	{
		protected ContainerMapping currentMap;

		public StdPersistenceContainer()
		{ }

		
		public StdPersistenceContainer( ContainerMapping initCurrentMap )
		{
			currentMap = initCurrentMap;
		}

		
		public ContainerMapping ContainerMapping
		{
			get 
			{
				return currentMap;
			}
			set 
			{
				currentMap = value;
			}
		}

		public virtual void Execute( PersistableObject currentObject )
		{
		}

		
	}
}
