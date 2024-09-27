using System.ComponentModel.DataAnnotations;
using Lite.Db.Models;

namespace Litehome.Db.Models;

public class HomeMember : AbstractDbItem
{
	[Required]
	[MaxLength(128)]
	public string Name { get; set; }
}