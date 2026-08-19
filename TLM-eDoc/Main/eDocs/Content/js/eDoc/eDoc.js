function SearchFiles() {
  
    var selectFileName = $('#SearchName').val();
    var UserID = $('#UserID').val();
    var FolderId = $('#FolderId').val();
    
    $("#mt > tbody").html("");

    $.ajax({
        url: $("#FilterSelectedFiles").val(),
        type: "GET",
        dataType: "JSON",
        data: { selectFileName: selectFileName, id: UserID, FolderId: FolderId },
       

        success: function (data) {
            if (data != 0) {
                $.each(data, function (index, val) {

                    if (val.IslockedCheckd == 1) {


                        $('#mt').append(

                               '<tr ondblclick="opennew(' + val.FileId + ')" data-id=' + val.FileId + '>' +


                                '<td> <input type="checkbox" disabled id="' + val.FileId + '" /></td>' +
                                '<td> <img src="' + val.ImageType + '" width="20" height="20" /></td>' +
                                '<td>' + val.OriginalFileName + '</td>' +
                                '<td>' + val.Date + '</td>' +
                                '<td class="details"><a href="#"><i class="demo-pli-tag"></i>' + val.Tags + '</a> <span>' + val.Tags_All + '</span></td>' +
                                '<td>' + val.SysFileId + '</td>' +
                                '<td>' + val.FileSize + '</td>' +

                               '</tr>');

                    }

                    else {
                        $('#mt').append(

                           '<tr ondblclick="opennew(' + val.FileId + ')" data-id=' + val.FileId + '>' +


                            '<td> <input type="checkbox" id="' + val.FileId + '" /></td>' +
                            '<td> <img src="' + val.ImageType + '" width="20" height="20" /></td>' +
                            '<td>' + val.OriginalFileName + '</td>' +
                            '<td>' + val.Date + '</td>' +
                            '<td class="details"><a href="#"><i class="demo-pli-tag"></i>' + val.Tags + '</a> <span>' + val.Tags_All + '</span></td>' +
                            '<td>' + val.SysFileId + '</td>' +
                            '<td>' + val.FileSize + '</td>' +

                           '</tr>');

                    }




                });

              
            }

        },
       
    });


}


function SearchByCompany() {

    
    var CompanyDropdownID = $('#CompanyDropdownID option:selected').val();  
    var FolderId = $('#FolderId').val();

    $("#mt > tbody").html("");

    $.ajax({
        url: $("#SearchByCompany").val(),
        type: "GET",
        dataType: "JSON",
        data: { CompanyDropdownID: CompanyDropdownID, FolderId: FolderId},


        success: function (data) {
            if (data != 0) {
                $.each(data, function (index, val) {

                    if (val.IslockedCheckd == 1) {


                        $('#mt').append(

                               '<tr ondblclick="opennew(' + val.FileId + ')" data-id=' + val.FileId + '>' +


                                '<td> <input type="checkbox" disabled id="' + val.FileId + '" /></td>' +
                                '<td> <img src="' + val.ImageType + '" width="20" height="20" /></td>' +
                                '<td>' + val.OriginalFileName + '</td>' +
                                '<td>' + val.Date + '</td>' +
                                '<td class="details"><a href="#"><i class="demo-pli-tag"></i>' + val.Tags + '</a> <span>' + val.Tags_All + '</span></td>' +
                                '<td>' + val.SysFileId + '</td>' +
                                '<td>' + val.FileSize + '</td>' +

                               '</tr>');

                    }

                    else

                    {
                        $('#mt').append(

                           '<tr ondblclick="opennew(' + val.FileId + ')" data-id=' + val.FileId + '>' +


                            '<td> <input type="checkbox" id="' + val.FileId + '" /></td>' +
                            '<td> <img src="' + val.ImageType + '" width="20" height="20" /></td>' +
                            '<td>' + val.OriginalFileName + '</td>' +
                            '<td>' + val.Date + '</td>' +
                            '<td class="details"><a href="#"><i class="demo-pli-tag"></i>' + val.Tags + '</a> <span>' + val.Tags_All + '</span></td>' +
                            '<td>' + val.SysFileId + '</td>' +
                            '<td>' + val.FileSize + '</td>' +

                           '</tr>');

                    }
                   



                });


            }

        },

    });


}