
//For Maintenance in asset
$(document).on('nifty.ready', function () {

    // DROPZONE.JS
    // =================================================================
    // Require Dropzone
    // http://www.dropzonejs.com/
    // =================================================================
    Dropzone.options.demoDropzone = { // The camelized version of the ID of the form element
        // The configuration we've talked about above
        autoProcessQueue: false,
        uploadMultiple: true,
        parallelUploads: 25,
        maxFiles: 25,

        // The setting up of the dropzone
        init: function () {
            var myDropzone = this;
            //  Here's the change from enyo's tutorial...
            $("#submit-all").click(function (e) {
                e.preventDefault();
                e.stopPropagation();
                myDropzone.processQueue();

            }
              );

        }

    }



    // DROPZONE.JS WITH BOOTSTRAP'S THEME
    // =================================================================
    // Require Dropzone
    // http://www.dropzonejs.com/
    // =================================================================
    // Get the template HTML and remove it from the document template HTML and remove it from the doument
    var previewNodeMaintenance = document.querySelector("#dz-templateMaintenance");
    previewNodeMaintenance.id = "";
    var previewTemplateMaintenance = previewNodeMaintenance.parentNode.innerHTML;
    previewNodeMaintenance.parentNode.removeChild(previewNodeMaintenance);

    var uplodaBtnMaintenance = $('#dz-upload-btnMaintenance');
    var removeBtn = $('#dz-remove-btn');
    var myDropzoneMaintenance = new Dropzone('#MaintenanceDiv', { // Make the whole body a dropzone
        url: $('#SaveAssetMaintenance').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplateMaintenance,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previewsMaintenance", // Define the container to display the previews
        clickable: ".fileinput-buttonMaintenance" // Define the element that should be used as click trigger to select files.
    });


    myDropzoneMaintenance.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtnMaintenance.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzoneMaintenance.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzoneMaintenance.on("totaluploadprogress", function (progress) {
        $("#dz-total-progressMaintenance .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzoneMaintenance.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progressMaintenance").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzoneMaintenance.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progressMaintenance").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtnMaintenance.on('click', function () {
        //Upload all files
        myDropzoneMaintenance.enqueueFiles(myDropzoneMaintenance.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneMaintenance.enqueueFiles(myDropzoneMaintenance.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneMaintenance.processQueue();



        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "Maintenance" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzoneMaintenance.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});