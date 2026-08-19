
//For warranty in asset
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
    var previewNodewarranty = document.querySelector("#dz-templateWarranty");
    previewNodewarranty.id = "";
    var previewTemplateWarranty = previewNodewarranty.parentNode.innerHTML;
    previewNodewarranty.parentNode.removeChild(previewNodewarranty);

    var uplodaBtnWarranty = $('#dz-upload-btnWarranty');
    var removeBtn = $('#dz-remove-btnWarranty');
    var myDropzoneWarranty = new Dropzone('#WarrantyDiv', { // Make the whole body a dropzone
        url: $('#SaveAssetWarranty').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplateWarranty,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previewsWarranty", // Define the container to display the previews
        clickable: ".fileinput-buttonWarranty" // Define the element that should be used as click trigger to select files.
    });


    myDropzoneWarranty.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtnWarranty.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzoneWarranty.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzoneWarranty.on("totaluploadprogress", function (progress) {
        $("#dz-total-progressWarranty .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzoneWarranty.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progressWarranty").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzoneWarranty.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progressWarranty").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtnWarranty.on('click', function () {
        //Upload all files
        myDropzoneWarranty.enqueueFiles(myDropzoneWarranty.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneWarranty.enqueueFiles(myDropzoneWarranty.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneWarranty.processQueue();



        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "Warranty" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzoneWarranty.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});