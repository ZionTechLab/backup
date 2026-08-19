Template_FieldListView = [];


function AddTemplateDetails()
{     debugger   
    ValidateForm();
    if (ValidateForm()) {
        var TemplateTemplateName = $('#TemplateTemplateName').val();
        var TemplateID = $('#pop-up-TemplateID').val();
     
        $("#demo-dt-selection2> tbody").html("");

        $.ajax({
            url: $("#AddTemplateDetails").val(),
            type: "POST",
            dataType: "JSON",
            data: { TemplateName: TemplateTemplateName, TemplateID: TemplateID },
            success: function (data) {
                
                if (data != null) {

                    $.each(data, function (index, value) {

                        $('#demo-dt-selection2').append(
                             '<tr>' +
                             '<td > ' + value.TemplateID + ' </td>' +
                             '<td> ' + value.TemplateName + ' </td>' +
                            
                            '<td> <button type="button"  onclick="GetTemplate(\'' + value.TemplateID + '\',\'' + value.TemplateName + '\')" class="btn btn-primary btn-xs">Edit</button> <button type="button"  onclick="DeleteTemplate(' + value.TemplateID + ')" data-dismiss="modal"  class="btn btn-danger btn-xs">Remove</button></td>' +
                            
                            '</tr>');




                    })



                }
            }


        }
        );

        $('#TemplateTemplateName').val('');
        $('#pop-up-TemplateID').val('');
        loadDropdown();

    }
}

function DeleteTemplate(TemplateID) {
   

    Swal.fire({

        title: 'Are you sure?',
        text: "Are you sure want to delete this record!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#294f75',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {

           
            $.ajax({
                url: $("#DeleteTemplateFunction").val(),
                type: "POST",
                dataType: "JSON",
                data: { TemplateID: TemplateID },
                success: function (data) {
                    console.log(data);
                    if (data != null) {
                      
                        location.reload();
                      
                    }
                },



            });



        }
    });



    loadDropdown();

}


function GetTemplate(TemplateID,TemplateName) {

    document.getElementById('pop-up-TemplateID').value = TemplateID;
    document.getElementById('txt_GetTempVal').value = TemplateName;


}







function AddFields() {

    ValidateForm_Main();
    if (ValidateForm_Main()) {

        var GetRowCount = $('#demo-dt-selection tr').length;

        if (GetRowCount <= 10) {
        $("#pop-upAlert").hide();
        var FieldName = $('#TemplateFieldName').val();
        var FieldsID = $('#TemplateFieldsID').val();      
        var parameterName = $('#TemplateFieldsID option:selected').html();
        var DefaultVal = 0;
        $('#demo-dt-selection').append(
                         '<tr>' +
                         '<td style="display:none" > ' + FieldsID + ' </td>' +
                         '<td> ' + FieldName + ' </td>' +
                         '<td> ' + parameterName + ' </td>' +

                         '<td><i style="cursor:pointer;" onclick="removeJob(this)" class="demo-pli-recycling"></i></td>' +
                         '<td style="display:none">' + DefaultVal + ' </td>' +
                        '</tr>');

        var item2 = {
            FieldsIDName: FieldsID,
            FieldName: FieldName,
            parameterName: parameterName,
            DefaultVal: DefaultVal
        }

        Template_FieldListView.push(item2); 


        $('#TemplateFieldName').val('');
        $('#TemplateFieldsID').prop('selectedIndex', 0);
        

        }

        else

        {
            $("#pop-upAlert").show();
            
        }

    }

}

function removeJob(btnRemove) {
    $(btnRemove).closest("tr").remove();
  
    Template_FieldListView.length = 0;
    var row_count = $('#demo-dt-selection tr').length;
    console.log(row_count + ' row count');

    for (var i = 1; i < row_count; i++) {


        FieldsID = $('#demo-dt-selection tr:nth-child(' + i + ') td:nth-child(1)').text();
        FieldName = $('#demo-dt-selection tr:nth-child(' + i + ') td:nth-child(2)').text();
        parameterName = $('#demo-dt-selection tr:nth-child(' + i + ') td:nth-child(3)').text();
        DefaultVal = $('#demo-dt-selection tr:nth-child(' + i + ') td:nth-child(5)').text();

        var item2 = {
            FieldsID: FieldsID,
            FieldName: FieldName,
            parameterName: parameterName,
            DefaultVal: DefaultVal,
        }

        Template_FieldListView.push(item2);

    }


}

function SaveTemplate() {

    ValidateTemplateName();
    if (ValidateTemplateName()) {

        var param = {
            
           TemplateTemplateID: $('#TemplateTemplateID').val(),
           Template_FieldListView: Template_FieldListView,
      
        }

        $.ajax({
            url: $("#SaveTemplate").val(),
            type: "POST",
            dataType: "JSON",
            data: { model: param },
            success: function (data) {
               
                if (data != null) {

                    location.reload();

                }
            },



        });

    }
}


function ValidateForm_Main() {

    var inputValue = $("#TemplateFieldName").val($.trim($("#TemplateFieldName").val()));

    var result = true;
   
    $('span[data-valmsg-for="TemplateFieldName"]').text('');
    if ($('#TemplateFieldName').val() == "") {
        $('span[data-valmsg-for="TemplateFieldName"]').text('Field Name is required.');
        result = false;
    }


    $('span[data-valmsg-for="TemplateFieldsID"]').text('');
    if ($('#TemplateFieldsID option:selected').text() == "Select Field") {
        $('span[data-valmsg-for="TemplateFieldsID"]').text('Select Field');
        result = false;
    }

    return result;
}

function ValidateTemplateName() {


    var result = true;

    $('span[data-valmsg-for="TemplateTemplateID"]').text('');
    if ($('#TemplateTemplateID option:selected').text() == "Select Template") {
        $('span[data-valmsg-for="TemplateTemplateID"]').text('Select Template');
        result = false;
    }

    return result;
}

function removeTemplateDetailsLine(value) {


    Swal.fire({

        title: 'Are you sure?',
        text: "Are you sure want to delete this record!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#294f75',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {


            $.ajax({
                url: $("#removeTemplateDetailsLine").val(),
                type: "POST",
                dataType: "JSON",
                data: { TemplateDetailsID: value },
                success: function (data) {
                    console.log(data);
                    if (data != null) {

                        location.reload();

                    }
                },



            });



        }
    });

}


function ValidateFormTemplate() {

    var inputValue = $("#txt_GetTempVal").val($.trim($("#txt_GetTempVal").val()));
    var result = true;

    $('span[data-valmsg-for="txt_GetTempVal"]').text('');
    if ($('#txt_GetTempVal').val() == "") {
        $('span[data-valmsg-for="txt_GetTempVal"]').text('Template Name is required.');
        result = false;
    }




    return result;
}
function GetTempVal() {

    ValidateFormTemplate();
    if (ValidateFormTemplate()) {

        var txt_GetTempVal = $('#txt_GetTempVal').val();
        var popupTemplateID = $('#pop-up-TemplateID').val();

        $("#demo-dt-selection2> tbody").html("");

        $.ajax({
            url: $("#AddTemplateDetails").val(),
            type: "POST",
            dataType: "JSON",
            data: { TemplateName: txt_GetTempVal, TemplateID: popupTemplateID },
            success: function (data) {

                if (data != null) {

                    $.each(data, function (index, value) {

                        $('#demo-dt-selection2').append(
                             '<tr>' +
                             '<td > ' + value.TemplateID + ' </td>' +
                             '<td> ' + value.TemplateName + ' </td>' +

                            '<td> <button type="button"  onclick="GetTemplate(\'' + value.TemplateID + '\',\'' + value.TemplateName + '\')" class="btn btn-primary btn-xs">Edit</button> <button type="button"  onclick="DeleteTemplate(' + value.TemplateID + ')" data-dismiss="modal"  class="btn btn-danger btn-xs">Remove</button></td>' +

                            '</tr>');




                    })



                }
            }


        }
        );

        $('#txt_GetTempVal').val('');
        $('#pop-up-TemplateID').val('');
        loadDropdown();

    }
}



function loadDropdown() {

    $.ajax({
        url: $("#loadDropdown").val(),
        type: "POST",
        dataType: "JSON",
        success: function (RackList) {
            $("#TemplateTemplateID").html(""); // clear before appending new list
            $("#TemplateTemplateID").append($('<option></option>').val(0).html("Select Template"));
            $.each(RackList, function (i, iou) {

                $("#TemplateTemplateID").append($("<option     />").val(iou.DocumentTypeId).text(iou.ContainerType));

               


            });



        },


        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);

        }

    });



}