﻿using Forge.Engine;
using Forge.Networking.Messaging.Interpreters;
using Forge.Serialization;

namespace Forge.Networking.Messaging.Messages
{
	public abstract class ForgeEntityMessage : ForgeMessage, IEntityMessage
	{
		public int EntityId { get; set; }

		public override IMessageInterpreter Interpreter => new ForgeEntityMessageInterpreter();

		public abstract void ProcessUsing(IEntity entity);

		public override void Deserialize(BMSByte buffer)
		{
			byte[] s = ForgeSerializationStrategy.Instance.Serialize(EntityId);
			buffer.Append(s);
		}

		public override void Serialize(BMSByte buffer)
		{
			EntityId = buffer.GetBasicType<int>();
		}
	}
}