﻿using System;
using System.Collections.Generic;
using System.Security;
using mRemoteNG.Config.DataProviders;
using mRemoteNG.Config.Serializers;
using mRemoteNG.Config.Serializers.CredentialSerializer;
using mRemoteNG.Credential;


namespace mRemoteNG.Config
{
    public class CredentialRecordSaver
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly XmlCredentialRecordSerializer _serializer;

        public CredentialRecordSaver(IDataProvider<string> dataProvider, XmlCredentialRecordSerializer serializer)
        {
            if (dataProvider == null)
                throw new ArgumentNullException(nameof(dataProvider));
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));

            _dataProvider = dataProvider;
            _serializer = serializer;
        }

        public void Save(IEnumerable<ICredentialRecord> credentialRecords)
        {
            var serializedCredentials = _serializer.Serialize(credentialRecords);
            _dataProvider.Save(serializedCredentials);
        }
    }
}