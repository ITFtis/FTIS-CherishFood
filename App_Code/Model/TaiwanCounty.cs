using System.Collections.Generic;

namespace Model
{
    public class County
    {
        public string CityName { get; set; }
        public string CityEngName { get; set; }
        public string CityCode { get; set; }
        public int Sort { get; set; }
        public List<District> AreaList { get; set; }
    }

    public class District
    {
        public string ZipCode { get; set; }
        public string AreaName { get; set; }
        public string AreaEngName { get; set; }
    }
}
