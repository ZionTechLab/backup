
//For Licenses in asset
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
    var previewNodeLicenses = document.querySelector("#dz-templateLicenses");
    previewNodeLicenses.id = "";
    var previewTemplateLicenses = previewNodeLicenses.parentNode.innerHTML;
    previewNodeLicenses.parentNode.removeChild(previewNodeLicenses);

    var uplodaBtnLicenses = $('#dz-upload-btnLicenses');
    var removeBtn = $('#dz-remove-btnLicenses');
    var myDropzoneLicenses = new Dropzone('#LincenseDiv', { // Make the whole body a dropzone
        url: $('#SaveAssetLicenses').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplateLicenses,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previewsLicenses", // Define the container to display the previews
        clickable: ".fileinput-buttonLicenses" // Define the element that should be used as click trigger to select files.
    });


    myDropzoneLicenses.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtnLicenses.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzoneLicenses.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzoneLicenses.on("totaluploadprogress", function (progress) {
        $("#dz-total-progressLicenses .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzoneLicenses.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progressLicenses").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzoneLicenses.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progressLicenses").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtnLicenses.on('click', function () {
        //Upload all files
        myDropzoneLicenses.enqueueFiles(myDropzoneLicenses.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneLicenses.enqueueFiles(myDropzoneLicenses.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneLicenses.processQueue();



        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "Licenses" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzoneLicenses.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});
