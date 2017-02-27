using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationConvertor
{
    class DataFlowObject
    {
        string _startDataFlow = "{\n\t\"name\": \"\",\n\t\"description\": \"\",\n\t\"steps\": [";
        string _endDataFlow = "\n}\n]\n}";
        string _accountReadStart = "{\n\t\t\t\"id\": \"accounts\",\n\t\t\t\"type\": \"datasource.read.gigya.account\",\n\t\t\t\"params\": {\n\t\t\t\t\"select\": \"";
        string _accountReadEnd = "\"\n},\n\"next\": [\"rename\"]\n}, {\n\"id\": \"rename\",\n\"type\": \"field.rename\",\n\"params\": {\n\"fields\": [";
        string _accountReadFull;
        convertFile _convertFile;
        string _fileCompleted;
        public string buildDataFlow(string fileLegacy)
        {
            _convertFile = new convertFile(fileLegacy);
            string _fieldsOnly = _convertFile.convertFieldsMapping().ToString();
            _fileCompleted = _startDataFlow + _accountReadStart + _convertFile._selectFields + _accountReadEnd + _fieldsOnly + _endDataFlow;
            return _fileCompleted;
        }
    }
}
