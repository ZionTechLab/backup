$(document).ready(function () {
    setTimeout(function () {
        $('#divStatusMsg').fadeOut('slow');
    }, 3000); // <-- time in milliseconds

    $('.datatable').DataTable();
    $('.search').select2();
    $('.date_picker').daterangepicker({
        singleDatePicker: true,
        calender_style: "picker_4"
    }, function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
    });
    $.ajax({

        url: $('#NotificationURL').val(),
        type: 'GET',
        dataType: "JSON",
        data: {},
        success: function (result) {
            console.log(result);

            if (result.length > 0) {
                document.getElementById("count").style.display = "block";
                document.getElementById("count").textContent = result.length;
                $listSelector = $("#menu1");
                $.each(result, function (i, obj) {

                    $listSelector.append("<li>"
                                            + "<a onClick=NotificationSeen(" + obj.id + ")>"
                                            + " <span class='glyphicon glyphicon-hourglass'></span> "
                                            + "<span><span>Reorder Levels</span><span class='time'>" + obj.time + " hour ago</span></span>"
                                            + " <span class='message'>" + obj.message + "</span>"
                                            + "</a>"
                                            + "</li>");
                });
            } else {
                $listSelector = $("#menu1");
                document.getElementById("count").style.display = "none";

            }

        }
    });
    //$('.date-picker').daterangepicker({
    //     singleDatePicker: true,
    //     calender_style: "picker_4"
    // }, function (start, end, label) {
    //     console.log(start.toISOString(), end.toISOString(), label);
    // });
});

$('.delete').on('click', function () {
    var id = $(this).attr('data-id');
    var dataType = $(this).attr('data-type');
    console.log('Id - ' + id + ' type - ' + dataType);
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete It!',
        cancelButtonText: 'Cancel'
    }).then(function (isConfirm) {
        if (isConfirm.value == true) {
            $.ajax
            ({
                url: $('#DeleteURL').val(),
                type: 'POST',
                data: { Id: id, type: dataType },
                async: false,
                datatype: "json",
                success: function (data) {
                    if (data == "success") {
                        swal("Deleted!", "Deleted Successfully.", "success").then(function (confirm) {
                            if (confirm) {
                                location.reload();
                            }
                        });
                    } else {
                        swal("Failed!", "Operation Failed", "error").then(function (confirm) {
                            if (confirm) {
                                location.reload();
                            }
                        });
                    }

                }
            });
        }
        else {
            swal("Cancelled", "Safe ! Not Successfully Deleted", "error");
        }
    });
});