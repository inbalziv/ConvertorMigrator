using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MigrationConvertor
{
    class FieldMapping
    {
        [JsonProperty("_source")]
        public string _source { get; set; }
        [JsonProperty("_target")]
        public string _target { get; set; }

        public FieldMapping(string source, string target)
        {
            this._source = source;
            this._target = target;
        }
        public override string ToString()
        {
            return "\"sourceField\": \"" + this._source + "\",\n\"targetField\": \"" + this._target + "\"";
        }
    }
}
