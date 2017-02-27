using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationConvertor
{
    class convertFile
    {
        string _fileLegacy;
         
               
        public string _selectFields { get; private set; }
        private List<FieldMapping> _fieldMappingList;



        public convertFile(string file)
        {
            _fileLegacy = file;
            _selectFields = "";

        }
        public string convertFieldsMapping()
        {

            if (convertToList(findFieldsMapping().TrimStart()))
                return outputFields();
            // return convertListToJson();
            else return "Oops! Something went wrong in Fields Mapping";

        }
        private string findFieldsMapping()
        {
            string _fieldsMappingOnly = "";
            if (_fileLegacy.Contains("[fieldMapping]"))
            {
                int start = _fileLegacy.IndexOf("[fieldMapping]") + "[fieldMapping]".Length;
                if (start > 0 )
                {
                    string startFieldsMapping = _fileLegacy.Substring(start, _fileLegacy.Length - start);
                    startFieldsMapping.TrimStart();
                    if (startFieldsMapping.IndexOf("[connector]") > 0)
                        return startFieldsMapping.Substring(0, startFieldsMapping.IndexOf("[connector]")).TrimEnd();
                    else return startFieldsMapping.TrimEnd();
                }
                
            }
            return _fieldsMappingOnly;
        }
        private bool convertToList(string fieldsMapping)
        {
            int i = 0;
            int index;
            string[] _fieldsArr = fieldsMapping.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (_fieldsArr.Length > 0)
            {
                this._fieldMappingList = new List<FieldMapping>();
                FieldMapping _fieldMapping;
                while (i < _fieldsArr.Length)
                {
                    
                    if ((_fieldsArr[i] != null) || (_fieldsArr[i] != ""))
                    {
                        _fieldsArr[i].Trim();
                        index = _fieldsArr[i].IndexOf("=");
                        string source = _fieldsArr[i].Substring(0, index);
                        string target = _fieldsArr[i].Substring(index+1, _fieldsArr[i].Length-index-1);
                        if (source.Trim() != target.Trim())
                        {
                            _fieldMapping = new FieldMapping(source.Trim(), target.Trim());
                            _fieldMappingList.Add(_fieldMapping);
                        }
                        if (_selectFields == "")
                            _selectFields = source;
                        else _selectFields = _selectFields + "," + source;



                    }
                    i++;
                }
                
                return true;
            }
            else return false;

        }
        private string convertListToJson()
        {

            return "NYC";
        }
        public string outputFields()
        {
            string _fields = "";
            if (this._fieldMappingList != null)
            {
                for (int i = 0; i < _fieldMappingList.Count(); i++)
                    _fields = _fields + "{ \n" + _fieldMappingList[i].ToString() + "\n }," ;
            }
            return _fields.Substring(0, _fields.Length-1);
        }
        /*  public override string ToString()
          {

              return _fields;
          }


          {
      "name": "Fox_Responsys_FoxDotCom_outbound",
      "description": "accounts > rename > csv > sftp",
      "steps": [{
              "id": "accounts",
              "type": "datasource.read.gigya.account",
              "params": {
                  "select": "UID,profile.age,profile.email,profile.gender,profile.firstName,profile.lastName,profile.birthYear,profile.nickname,profile.username,profile.address,profile.country,profile.state,profile.city,profile.zip,data.subscribe"
              },
              "next": ["rename"]
          }, {
              "id": "rename",
              "type": "field.rename",
              "params": {
                  "fields": [
          */
    }
}
