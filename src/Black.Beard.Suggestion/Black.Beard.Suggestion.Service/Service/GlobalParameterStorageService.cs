using System;
using System.Collections;
using Black.Beard.Caching.Contracts;
using System.Collections.Generic;
using Bb.Sdk;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;

namespace Bb.Service
{

    public class GlobalParameterStorageService : IGlobalParameterStorageService
    {


        public GlobalParameterStorageService(string folder, string formatDate = "dd-MM-yyyy HH:mm:ss")
        {

            this._formatDate = formatDate;
            this._dir = new DirectoryInfo(folder);

            if (!_dir.Exists)
                _dir.Create();

        }

        public bool Del(string name)
        {
            FileInfo file = GetFile(name);
            file.Refresh();
            if (file.Exists)
            {
                file.Delete();
                file.Refresh();
                return true;
            }

            return false;

        }

        public IEnumerable<GlobalParameter> List()
        {
            foreach (var file in this._dir.GetFiles("*.txt"))
                yield return LoadFile(file);
        }

        public GlobalParameter Get(string name)
        {
            FileInfo file = GetFile(name);
            if (file.Exists)
                return LoadFile(file);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FileInfo GetFile(string name)
        {
            return new FileInfo(Path.Combine(this._dir.FullName, $"{name}.txt"));
        }

        public void Set(GlobalParameter parameter)
        {

            FileInfo file = GetFile(parameter.Name);
            file.Refresh();
            SaveFile(file, parameter.Value, parameter.Type, parameter.LastUpdate);
        }

        private void SaveFile(FileInfo file, object value, Type type, DateTime date)
        {

            StringBuilder sb = new StringBuilder(1000);

            sb.AppendLine(type.AssemblyQualifiedName);
            sb.AppendLine(date.ToString(this._formatDate));
            sb.Append((string)Convert.ChangeType(value, typeof(string)));

            var payload = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            using (var stream = file.Open(FileMode.Create, FileAccess.Write))
            {
                stream.Write(payload, 0, payload.Length);
            }

        }

        private GlobalParameter LoadFile(FileInfo file)
        {
            if (file != null && file.Exists)
            {

                try
                {


                    using (StreamReader stream = file.OpenText())
                    {

                        var _type = stream.ReadLine();
                        Type type = Type.GetType(_type);
                        if (type == null)
                            throw new InvalidDataException($"the type {_type} file variable {file.Name} can't be resolved");

                        var _date = stream.ReadLine();
                        var date = DateTime.ParseExact(_date, this._formatDate, CultureInfo.InvariantCulture);

                        var data = stream.ReadToEnd();
                        return new GlobalParameter()
                        {
                            Name = Path.GetFileNameWithoutExtension(file.Name),
                            Value = Convert.ChangeType(data, type),
                            LastUpdate = date,
                            Type = type,
                        };

                    }

                }
                catch (Exception e)
                {

                    throw;
                }

            }

            return null;

        }

        private readonly DirectoryInfo _dir;
        private string _formatDate;
    }

    internal class GlobalParameterStorage
    {

        public string Type { get; set; }

        public string Value { get; set; }

    }


}