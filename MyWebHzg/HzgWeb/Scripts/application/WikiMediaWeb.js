//$(document).ready(function () {

//    alert("Hello World");


//})

function showMovieModal(ctl, showDelete) {

    var options = {
        "backdrop": "static",
        "keyboard": true
    }

    // Body mit Daten initialisieren
    var modalBody = $('#movieModal #body');
    $(modalBody).empty();

    var rows = $('#movieTable').find('th');
    var row = $(ctl).parent().parent();    

    var columns = $(row).find('td');

    modalBody.append($('<dt>').html(rows[1].innerText));
    modalBody.append($('<dd>').html(columns[1].innerText));

    modalBody.append($('<dt>').html(rows[3].innerText));
    modalBody.append($('<dd>').html(columns[2].innerText + ' | ' + columns[3].innerText));

    modalBody.append($('<dt>').html(rows[5].innerText));
    modalBody.append($('<dd>').html(columns[5].innerText + ' | ' + columns[4].innerText));

    modalBody.append($('<dt>').html(rows[6].innerText));
    modalBody.append($('<dd>').html(columns[6].innerText));

    modalBody.append($('<dt>').html(rows[7].innerText));
    modalBody.append($('<dd>').html(columns[7].innerText));

    modalBody.append($('<dt>').html(rows[8].innerText));
    modalBody.append($('<dd>').html(columns[8].innerText));

    // Header initialisieren
    var modalHeader = $('#movieModal #header');
    if (showDelete) {
        $(modalHeader).html($('<h4>').text("Wollen Sie diesen Datensatz wirklich löschen?"));
        $('#movieModal #modDelete').removeClass('hidden');
        // Id aus Feld mit Index 0 holen
        $('#movieModal #id').val(columns[0].innerText);
    }
    else {
        $('#movieModal #modDelete').addClass('hidden');
        $(modalHeader).html($('<h4>').text("Details"));    
        // Id auf ungültigen Wert setzen
        $('#movieModal #id').val('');
    }


    $('#movieModal').modal(options);
}


/* Create methods */

function CreateAddress() {
    var uri = GetBaseURI() + "/Address";
    var contentType = GetContentType();
    var dataType = GetDataType();

    $.ajax({

        type: "POST", // Type entspricht dem HTTP Verb (GET, POST, PUT, DELETE, HEAD, OPTION)
        url: uri, // URL entspricht dem URI der REST Ressource
        //dataType: dataType,
         contentType: contentType,

        // Accept Header
        ///headers: { Accept: contentType },

        async: false,
        processData: false,
        cache: false,

        success: function (data, status, xhr) {

            if(status == 'success')
            {
                var newRessourceUri = xhr.getResponseHeader('Location');
                $('#TextAreaResult').val(xhr.getResponseHeader('Location'));

                UpdateAddress(0, null, newRessourceUri);
            }
        },

        error: function (data) {
            alert('An error occurred! Please contact your administrator.');
        }
    });

}


/* Read methods */

function GetAddresses()
{
    var uri = GetBaseURI();
    uri += "/Address";
    var dataType = GetDataType();

    var username = "Admin";
    var password = "123456";

    var credentials = btoa(username + ":" + password);
     
    //    alert(uri);
    //    location.href = uri;

    // load data mit JQuery AJAX

    // jQuery.ajax({})

    $.ajax({

        type: "GET", // Type entspricht dem HTTP Verb (GET, POST, PUT, DELETE, HEAD, OPTION)
        url: uri, // URL entspricht dem URI der REST Ressource
        dataType: dataType,
        contentType: GetContentType(),

        // Accept Header
        headers: {
            Accept: GetContentType(),
            Authorization: "Basic " + credentials
            // "authorization": "Basic " + credentials
        },
        
        async: false,
        processData: false,
        cache: false,

        success: function (data, status, xhr){

            var resultString = (dataType == "json") ? JSON.stringify(data) : jQuery(data).text();

            //var result = jQuery.parseXML(resultString);
            //var addresses = $(result).find('XMLAddress');
            //var lastName = $(addresses[0]).find('Lastname').text();
            $("#TextAreaResult").val(resultString);

            // Daten mit parseJSON deserialisieren
            // var deserializedData = $.parseJSON(data);
        },

        error: function(data){
            alert('An error occurred! Please contact your administrator.');
        }
    });

}


function GetAddressesByLastname() {
    var uri = GetBaseURI();
    uri += "/Address";

    var filterCriteria = $('#FilterCriteria').val();
    uri += "/?lastname=" + filterCriteria

    var dataType = GetDataType();

    $.ajax({

        type: "GET", // Type entspricht dem HTTP Verb (GET, POST, PUT, DELETE, HEAD, OPTION)
        url: uri, // URL entspricht dem URI der REST Ressource
        dataType: dataType,
        contentType: GetContentType(),

        // Accept Header
        headers: { Accept: GetContentType() },

        async: false,
        processData: false,
        cache: false,

        success: function (data, status, xhr) {

            var resultString = (dataType == "json") ? data : jQuery(data).text();
            $("#TextAreaResult").val(resultString);
        },

        error: function (data) {
            alert('An error occurred! Please contact your administrator.');
        }
    });

}


function UpdateAddress(id, objData, uri)
{
    if(uri == undefined || uri == null)
    {
        uri = GetBaseURI() + "/address";

        /* PUT benötigt eine Referenz auf eine Ressource, um diese zu aktualisieren. */
        uri += "/" + id;
    }
        
    var contentType = GetContentType();
    var dataType = GetDataType();

    if (objData == undefined) {

        switch (dataType) {
            case "xml":
                objData = GetUpdateAddressDataXML(0);
                break;

            case "json":
                objData = GetUpdateAddressDataJSON(0);
        }
    }
    
        
    $.ajax({

        type: "PUT", // Für Update oder um eine neue Ressource anzulegen
        url: uri,   // URL entspricht dem URI der REST Ressource
        dataType: dataType,
        contentType: contentType,

        data: objData,
        
        // Accept Header
        headers: { Accept: contentType },

        async: false,
        processData: false,
        cache: false,

        success: function (data, status, xhr) {

            var resultString = (dataType == "json") ? JSON.stringify(data) : jQuery(data).text();
            $("#TextAreaResult").val(resultString);
            
        },

        error: function (data) {
            alert('An error occurred! Please contact your administrator.');
        }
    });

}


function DeleteAddress()
{
    var uri = GetBaseURI();
    uri += "/Address";

    var id = $("#FilterCriteria").val();
    uri += "/" + id;

    var dataType = GetDataType();
        
    $.ajax({

        type: "DELETE", // Type entspricht dem HTTP Verb (GET, POST, PUT, DELETE, HEAD, OPTION)
        url: uri, // URL entspricht dem URI der REST Ressource
        // dataType: dataType,
        // contentType: GetContentType(),

        // Accept Header
        headers: { Accept: GetContentType() },

        async: false,
        processData: false,
        cache: false,

        success: function (data, status, xhr) {
            $("#TextAreaResult").val(status);
        },

        error: function (data) {
            alert('An error occurred! Please contact your administrator.');
        }
    });

}


function GetUpdateAddressDataJSON(id) {

    /* Z am Ende für Zulu aka Greenwich mean time */
    var createDate = ConvertToJSONDate('2016-04-08T20:20:35');

    return JSON.stringify({
        AdrNo: id, Salutation: 'Herr', Title: null, Lastname: 'Mustermann', Firstname: 'Max', Street: 'Kirchgasse 1',
        City: 'Feldkirch', ZipCode: '6800', CountryCd: 'AT', AgrCD: '3', Phone: '0680-1234567', Email: 'max.mustermann@yahoo.com', CreateDate: createDate, CreateUser: 'Admin'
    });
}


function GetUpdateAddressDataXML(id) {

    /* Wichtig - Properties müssen in alphabetischer Reihenfolge übermittelt werden, 
                     oder man verwendet das Order = 1, 2, 3 Attribut */
    var objData = '<AddressModel xmlns="http://www.synthpop.at/WikiMedia">';
    objData += '<Salutation>Herr</Salutation>';
    objData += '<Title>Mag.</Title>';
    objData += '<Firstname>Max</Firstname>';
    objData += '<Lastname>Mustermann</Lastname>';
    objData += '<Additional></Additional>';
    objData += '<Street>Kirchgasse 1</Street>';
    objData += '<City>Feldkirch</City>';
    objData += '<ZipCode>6800</ZipCode>';
    objData += '<CountryCd>AT</CountryCd>';
    objData += '<AgrCD>3</AgrCD>';
    objData += '<Phone>0680-1234567</Phone>';
    objData += '<FaxNo></FaxNo>';
    objData += '<Email>max.mustermann@yahoo.com</Email>';
    objData += '<WebSite></WebSite>';
    objData += '<Foundation>0</Foundation>';
    objData += '<Description></Description>';
    objData += '<MailMerge>false</MailMerge>';
    objData += '<AdrNo>' + id + '</AdrNo>';
    objData += '<CreateUser>Admin</CreateUser>';
    objData += '<CreateDate>2016-04-08T20:20:35</CreateDate>';
    objData += '<ModifyUser>Admin</ModifyUser>';
    objData += '<ModifyDate>0001-01-01T00:00:00</ModifyDate>';
    objData += '</AddressModel>';

    return objData;

}

/*
CONVERT Date to JSON format
*/
function ConvertToJSONDate(strDate) {
    var dt = new Date(strDate);
    var newDate = new Date(Date.UTC(dt.getFullYear(), dt.getMonth(), dt.getDate(), dt.getHours(), dt.getMinutes(), dt.getSeconds(), dt.getMilliseconds()));
    return '/Date(' + newDate.getTime() + ')/';
}


function GetBaseURI()
{
    var uri = "http://localhost:8080/RestServiceImpl.svc";
    return uri;
}

function GetContentType()
{
    return 'application/' + ($("#ForceXML").prop('checked') ? 'xml' : 'json') + ";charset=UTF-8";
}

function GetDataType() {
    return $("#ForceXML").prop('checked') ? 'xml' : 'json';
}

// TreeView Methodes
function InitDirectoryNode(ctl, nodePath) {
    $.ajax({

        type: "POST",
        url: "/Movie/GetDirectoryChildNodes",
        dataType: "json",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify({ parentPath: nodePath }),
        async: true,
        processData: false,
        cache: false,
        success: function (data, status, shr) {
            //alert(data.length);
            if (data.length > 0) {

                var parentLi = $(ctl).parent('li');
                var ctlParentNode = $("<ul>");
                $.each(data, function (index, element) {

                    var onClick = "InitDirectoryNode(this, '" + element.Path + "');";

                    // Create new node
                    CreateNode(element, ctlParentNode, onClick);
                });

                // Add new node
                parentLi.append(ctlParentNode);
                $(ctl).attr("onclick", "ExpandCollapse(this);");
                ExpandCollapse(ctl);
            }
        },
        error: function () {
            alert("An error occurd. \n Please contact your administrator.");
        }
    });

}

function CreateNode(nodeData, ctlParentNode, onclickFunction) {

    var ctlNode = $('<li>');
    // javascript klassisch
    ctlNode.attr("style", "white-space: nowrap;");
    // jQuery
    $(ctlNode).css("white-space", "nowrap");

    var ctlNodeText = $("<span>");
    var ctlNodeIcon = $("<i class='glyphicon' >");

    var title = $("#ExpandText").val();

    if (nodeData.HasChilds) {
        ctlNode.addClass('parent_li');

        ctlNodeText.attr("onclick", onclickFunction);
        ctlNodeText.attr("title", title);

        ctlNodeIcon.addClass("glyphicon-plus-sign");
    }
    else {
        ctlNodeIcon.addClass("glyphicon-minus-sign");
    }

    ctlNodeText.append(ctlNodeIcon);
    ctlNodeText.append("&nbsp;");

    ctlNodeText.append(nodeData.Text);
    ctlNode.append(ctlNodeText);

    // Node ausblenden
    ctlNode.hide();
    ctlParentNode.append(ctlNode);

}

