using System.Collections.Generic;

namespace PartyInvites.Models
{
	public static class Repository
	{
		public static List<GuestResponse> Responses { get; } = new();

		public static void AddResponse(GuestResponse response)
		{
			Responses.Add(response);
		}
	}
}