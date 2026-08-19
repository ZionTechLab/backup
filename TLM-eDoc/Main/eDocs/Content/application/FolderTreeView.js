function SaveNewFolder() {

    ValidateForm();
    if (ValidateForm()) {


        var CreateNewFolderID = $('#CreateNewFolderID').val();
        var CreateNewFolderName = $('#CreateNewFolderName').val();

        $.ajax({
            url: $("#Validate_SaveNewFolder").val(),
            type: "POST",
            dataType: "JSON",
            data: { CreateNewFolderName: CreateNewFolderName, CreateNewFolderID: CreateNewFolderID },
            success: function (data) {

                if (data == true) {

                    $.ajax({
                        url: $("#SaveNewFolder").val(),
                        type: "POST",
                        dataType: "JSON",
                        data: { CreateNewFolderID: CreateNewFolderID, CreateNewFolderName: CreateNewFolderName },
                        success: function (data) {

                            if (data == 2) {

                                location.reload();

                            }


                            if (data == 1) {

                                $.niftyNoty({
                                    type: 'info',
                                    container: 'floating',
                                    title: 'Access Denied.',
                                    message: 'You dont have permission to save folder please contact your Administrator',
                                    closeBtn: true,
                                    floating: {
                                        position: "top-right",
                                        animationIn: "lightSpeedIn",
                                        animationOut: "lightSpeedOut"
                                    },
                                    timer: 3000,
                                    onShown: function () {
                                        $('#CreateNewFolderName').val('');

                                    }

                                });

                            }
                        },



                    });


                }

               
                else {
                    $.niftyNoty({
                        type: 'info',
                        container: 'floating',
                        title: 'Notice',
                        message: 'Sorry. folder name already exists',
                        closeBtn: true,
                        floating: {
                            position: "top-right",
                            animationIn: "lightSpeedIn",
                            animationOut: "lightSpeedOut"
                        },
                        timer: 3000,
                        onShown: function () {
                            $('#CreateNewFolderName').val('');

                        }

                    });
                }


            
            },



        });

     
    }
}


function GetFolder_RenameDetails(id) {

  
    $.ajax({
        url: $("#GetFolder_RenameDetails").val(),
        type: "POST",
        dataType: "JSON",
        data: { FolderRenameID: id },
        success: function (data) {

            if (data != "") {

                $('#FolderRenameChangeNewVal').val(data).trigger('change');
             


            }


        },



    });
    

}

function FolderRename() {

    ValidateForm_Rename();
    if (ValidateForm_Rename()) {

        var FolderRenameID = $('#FolderRenameID').val();
        var FolderRename = $('#FolderRenameChangeNewVal').val();


        $.ajax({
            url: $("#Validate_RenameFolder").val(),
            type: "POST",
            dataType: "JSON",
            data: { FolderRenameID: FolderRenameID, FolderRename: FolderRename },
            success: function (data) {

                if (data == true) {

                    $.ajax({
                        url: $("#FolderRename").val(),
                        type: "POST",
                        dataType: "JSON",
                        data: { FolderRenameID: FolderRenameID, FolderRename: FolderRename },
                        success: function (data) {

                            if (data != null) {

                                location.reload();

                            }

                            if (date == 1) {

                                $.niftyNoty({
                                    type: 'info',
                                    container: 'floating',
                                    title: 'Access Denied.',
                                    message: 'You dont have permission to rename folder please contact your Administrator',
                                    closeBtn: true,
                                    floating: {
                                        position: "top-right",
                                        animationIn: "lightSpeedIn",
                                        animationOut: "lightSpeedOut"
                                    },
                                    timer: 3000,
                                    onShown: function () {


                                    }

                                });

                            }
                        },



                    });


                }

                else {
                    $.niftyNoty({
                        type: 'info',
                        container: 'floating',
                        title: 'Notice',
                        message: 'Sorry. folder name already exists in main folders structure ',
                        closeBtn: true,
                        floating: {
                            position: "top-right",
                            animationIn: "lightSpeedIn",
                            animationOut: "lightSpeedOut"
                        },
                        timer: 3000,
                        onShown: function () {


                        }

                    });
                }
            },



        });
      
    }
}

function ValidateForm() {

    var inputValue = $("#CreateNewFolderName").val($.trim($("#CreateNewFolderName").val()));
    
   
  
    var result = true;

    $('span[data-valmsg-for="CreateNewFolderName"]').text('');
    if ($('#CreateNewFolderName').val() == "") {
        $('span[data-valmsg-for="CreateNewFolderName"]').text('Folder Name is required.');
        result = false;
    }


   

    return result;
}
function ValidateForm_Rename() {

    var inputValue = $("#FolderRenameChangeNewVal").val($.trim($("#FolderRenameChangeNewVal").val()));
    var result = true;

    $('span[data-valmsg-for="FolderRenameChangeNewVal"]').text('');
    if ($('#FolderRenameChangeNewVal').val() == "") {
        $('span[data-valmsg-for="FolderRenameChangeNewVal"]').text('Name is required.');
        result = false;
    }




    return result;
}


function Deletefolder(nodeId) {
    

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
                url: $("#Deletefolder").val(),
                type: "POST",
                dataType: "JSON",
                data: { ID: nodeId },
                success: function (data) {
                    console.log(data);
                    if (data == true) {
                        $.niftyNoty({
                            type: 'success',
                            container: 'floating',
                            title: 'Success',
                            message: 'Successfully deleted your records.',
                            closeBtn: true,
                            floating: {
                                position: "top-right",
                                animationIn: "lightSpeedIn",
                                animationOut: "lightSpeedOut"
                            },
                            timer: 3000,
                            onShown: function () {
                                location.href = $("#RedirectToEmail").val();
                               
                                
                            }

                        });

                        

                    } else {
                        $.niftyNoty({
                            type: 'info',
                            container: 'floating',
                            title: 'Access Denied.',
                            message: 'You dont have permission to delete folder please contact your Administrator',
                            closeBtn: true,
                            floating: {
                                position: "top-right",
                                animationIn: "lightSpeedIn",
                                animationOut: "lightSpeedOut"
                            },
                            timer: 3000,
                            onShown: function () {
                                location.reload();
                            }

                        });
                    }
                },



            });

        }
    });
    

}




function SaveMovedFolder() {

    var MoveFile = $('#LoadMoveFolderID').val();
    var DefaultId = $('#LoadMoveFolderDefaultClickedNode').val();
    Swal.fire({
        title: 'Are you sure?',
        text: "Are you sure want to move this file!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#294f75',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Yes, move!'
    }).then((result) => {
        if (result.value) {

            $.ajax({
                url: $("#Validate_SaveMovedFolder").val(),
                type: "POST",
                dataType: "JSON",
                data: { MoveFile: MoveFile, DefaultId: DefaultId },
                success: function (data) {

                    if (data == true) {

                        $.ajax({
                            url: $("#SaveMovedFolder").val(),
                            type: "POST",
                            dataType: "JSON",
                            data: { MoveFile: MoveFile, DefaultId: DefaultId },
                            success: function (data) {
                                console.log(data);
                                if (data == true) {
                                    $.niftyNoty({
                                        type: 'success',
                                        container: 'floating',
                                        title: 'Success',
                                        message: 'Successfully moved your file.',
                                        closeBtn: true,
                                        floating: {
                                            position: "top-right",
                                            animationIn: "lightSpeedIn",
                                            animationOut: "lightSpeedOut"
                                        },
                                        timer: 3000,
                                        onShown: function () {
                                            location.reload();
                                        }

                                    });



                                } else {
                                    $.niftyNoty({
                                        type: 'info',
                                        container: 'floating',
                                        title: 'Access Denied.',
                                        message: 'You dont have permission to move folder please contact your Administrator',
                                        closeBtn: true,
                                        floating: {
                                            position: "top-right",
                                            animationIn: "lightSpeedIn",
                                            animationOut: "lightSpeedOut"
                                        },
                                        timer: 3000,
                                        onShown: function () {
                                            location.reload();
                                        }

                                    });
                                }
                            },



                        });


                    } else {
                        $.niftyNoty({
                            type: 'info',
                            container: 'floating',
                            title: 'Notice',
                            message: 'Sorry. folder name already exists in main folders structure ',
                            closeBtn: true,
                            floating: {
                                position: "top-right",
                                animationIn: "lightSpeedIn",
                                animationOut: "lightSpeedOut"
                            },
                            timer: 3000,
                            onShown: function () {
                              

                            }

                        });
                    }
                },



            });

          


        }
    });



   

}