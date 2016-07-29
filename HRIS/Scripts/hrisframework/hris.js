; var hris = {};
; (function ($) {
    var obj = [];
    var th = "ui-redmond";
    var themeButton = "orange";

    hris.list = {
        _getLOV: function (name) {
            if (obj[name] === null) {
                obj[name] = this._dbLOV(name);
                console.log('Existing  ', name, ' is Null, fillin with Data:', obj[name]);
            }

            return obj[name];
        },
        _dbLOV: function (name) {
            var source = {
                datatype: "json",
                dataFields: [
                { name: 'value', type: 'number' },
                { name: 'label', type: 'string' }
                ],
                url: '/api/list/' + name,
                async: false
            };


            return jsList = new $.jqx.dataAdapter(source, {
                autoBind: true,
                contentType: 'application/json; charset=utf-8'
            });
        }
    };
    hris.data = {
        _getRoleBased: function () {
            var dataLevel = hris.list._getLOV('getLevel');
            var valueType = hris.list._getLOV('getValueType');
            var policy = hris.list._getLOV('getPolicyType');
            var source =
            {
                datatype: 'json',
                datafields: [
                    { name: 'check', type: 'bool' },
                    { name: 'ID', type: 'number' },
                    { name: 'empLevel', type: 'number' },
                    { name: 'LevelName', value: 'empLevel', values: { source: dataLevel.records, value: 'value', name: 'label' } },
                    { name: 'policyType', type: 'number' },
                    { name: 'policyName', value: 'policyType', values: { source: policy.records, value: 'value', name: 'label' } },
                    { name: 'value', type: 'number' },
                    { name: 'valueType', type: 'number' },
                    { name: 'valueName', value: 'valueType', values: { source: valueType.records, value: 'value', name: 'label' } }
                ],
                //async: false,
                url: '/api/role/getRoleBased',
                updateRow: function (rowID, rowData, commit) {
                    console.log("Updaterow : " + rowid);
                    console.log("Updaterow : ", rowdata);
                    //rowdata.ID = rowid;
                    var uri = '/api/role/updateRoleBased/' + rowid;
                    $.ajax({
                        cache: false,
                        dataType: 'json',
                        url: uri,
                        contentType: 'application/json',
                        data: JSON.stringify(rowdata),
                        type: 'PUT',
                        success: function (data, status, xhr) {
                            // update command is executed.
                            console.log("Row Updated on ID : " + rowdata.ID);
                            commit(true);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(rowdata);
                            console.log('Error Update on ID : ' + rowdata.ID + ' Messages: ' + jqXHR.responseText);
                            var output = JSON.parse(jqXHR.responseText);
                            window.open('about:blank').document.body.innerText += output.StackTrace;
                            commit(false);
                        }
                    });
                },
                deleteRow: function (rowID, commit) {
                    // synchronize with the server - send delete command
                    // call commit with parameter true if the synchronization with the server is successful 
                    // and with parameter false if the synchronization failed.
                    commit(true);
                }
            };


            return dataAdapter = new $.jqx.dataAdapter(source, {
                //autoBind: true
            });

        },
        _getRoleBasedBypolicyType: function (policyType) {
            var dataLevel = hris.list._getLOV('getLevel');
            var valueType = hris.list._getLOV('getValueType');
            var policy = hris.list._getLOV('getPolicyType');
            return source =
            {
                datatype: 'json',
                datafields: [
                    { name: 'check', type: 'bool' },
                    { name: 'ID', type: 'number' },
                    { name: 'empLevel', type: 'number' },
                    { name: 'LevelName', value: 'empLevel', values: { source: dataLevel.records, value: 'value', name: 'label' } },
                    { name: 'policyType', type: 'number' },
                    { name: 'policyName', value: 'policyType', values: { source: policy.records, value: 'value', name: 'label' } },
                    { name: 'value', type: 'number' },
                    { name: 'valueType', type: 'number' },
                    { name: 'valueName', value: 'valueType', values: { source: valueType.records, value: 'value', name: 'label' } }
                ],
                //async: false,
                url: '/api/role/getRoleBasedBypolicyType/' + policyType,
                updateRow: function (rowID, rowData, commit) {
                    console.log("Updaterow : " + rowid);
                    console.log("Updaterow : ", rowdata);
                    //rowdata.ID = rowid;
                    var uri = '/api/role/updateRoleBased/' + rowid;
                    $.ajax({
                        cache: false,
                        dataType: 'json',
                        url: uri,
                        contentType: 'application/json',
                        data: JSON.stringify(rowdata),
                        type: 'PUT',
                        success: function (data, status, xhr) {
                            // update command is executed.
                            console.log("Row Updated on ID : " + rowdata.ID);
                            commit(true);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(rowdata);
                            console.log('Error Update on ID : ' + rowdata.ID + ' Messages: ' + jqXHR.responseText);
                            var output = JSON.parse(jqXHR.responseText);
                            window.open('about:blank').document.body.innerText += output.StackTrace;
                            commit(false);
                        }
                    });
                },
                deleteRow: function (rowID, commit) {
                    // synchronize with the server - send delete command
                    // call commit with parameter true if the synchronization with the server is successful 
                    // and with parameter false if the synchronization failed.
                    commit(true);
                }
            };
        },

        _dataAdapter: function(source) {
            return dataAdapter = new $.jqx.dataAdapter(source, {
                autoBind: true
            });
        },
        _getRoleBasedTree: function () {
            var treesource =
                   {
                       datatype: 'json',
                       datafields: [
                           { name: 'id', type: 'number' },
                           { name: 'parentid', type: 'number' },
                           { name: 'text', type: 'string' },
                           { name: 'value', type: 'number' }
                       ],
                       id: 'id',
                       async: false,
                       url: '/api/list/getRoleBasedTree'
                   };
            return dataAdapter = new $.jqx.dataAdapter(treesource, {
                contentType: 'application/json; charset=utf-8',
                loadComplete: function (records) {
                    //console.log('OK : ', records);
                },
                loadError: function (jqXHR, status, error) {
                    console.log('Retrieve Error : ', jqXHR.responseText);
                },
                beforeLoadComplete: function (records) {
                    // console.log(records);
                }
            });

        }
    };
    hris.general = {
        disable: function (value) {
            var i = $("#" + value);
            i.jqxDropDownList({ disabled: true });
            //document.getElementById(value).disabled = true;
        },
        enable: function (value) {
            var i = $("#" + value);
            i.jqxDropDownList({ disabled: true });
            //document.getElementById(value).disabled = false;
        },
        getData: function (value) {
            var i = $("#" + value);
            if (value !== null) { return i.val(); }
        },
        getDropDown: function (value) {
            var i = $("#" + value);
            if (value !== null) { return i.jqxDropDownList('val'); }
        },
        cleanDropDown: function (value) {
            var i = $("#" + value);
            if (value !== null) { return i.jqxDropDownList({ selectedIndex: -1 }); }
        },
        cleanInput: function (value) {
            var i = $("#" + value);
            if (value !== null) { return i.jqxInput('val', null); }
        },
        bindInput: function (div, value) {
            var i = $("#" + div);
            i.jqxInput({ width: '100%', height: '35px' });
            if (value !== null) { i.jqxInput('val', value); }
        },
        bindButton: function (div) {
            var i = $("#" + div);
            i.jqxButton({ width: '120px', height: '35px', theme: themeButton });
        },
        bindDropDown: function (div, value) {
            var i = $("#" + div);
            i.jqxDropDownList({ source: hris.list._getLOV(div), theme: th, disabled: false, height: '35px', displayMember: "label", valueMember: "value", width: '100%' });
            if (value !== null) { i.jqxDropDownList('val', value); }
        }
    };

})(jQuery);