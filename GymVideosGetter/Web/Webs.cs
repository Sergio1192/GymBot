using System;
using System.Linq;

namespace GymVideosGetter.Web
{
    public static class Webs
    {
        public static readonly IWeb GYM_VIRTUAL = new GymVirtualWeb();

        private static readonly IWeb[] _webs = new IWeb[] { GYM_VIRTUAL };

        public static IWeb GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var web = _webs.First(w => w.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return web;
        }
    }
}
