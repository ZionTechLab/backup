
// Form-File-Upload.js
// ====================================================================
// This file should not be included in your project.
// This is just a sample how to initialize plugins or components.
//
// - ThemeOn.net -

//For File in asset
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
    var previewNode = document.querySelector("#dz-template");
    previewNode.id = "";
    var previewTemplate = previewNode.parentNode.innerHTML;
    previewNode.parentNode.removeChild(previewNode);

    var uplodaBtn = $('#dz-upload-btn');
    var removeBtn = $('#dz-remove-btn');
    var myDropzone = new Dropzone(document.body, { // Make the whole body a dropzone
        url: $('#SaveFiles').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplate,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previews", // Define the container to display the previews
        clickable: ".fileinput-button" // Define the element that should be used as click trigger to select files.
    });


    myDropzone.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtn.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzone.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzone.on("totaluploadprogress", function (progress) {
        $("#dz-total-progress .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzone.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progress").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzone.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progress").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtn.on('click', function () {
        //Upload all files
        myDropzone.enqueueFiles(myDropzone.getFilesWithStatus(Dropzone.ADDED));
        myDropzone.enqueueFiles(myDropzone.getFilesWithStatus(Dropzone.ADDED));
        myDropzone.processQueue();
        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "File" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzone.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});

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
    var removeBtn = $('#dz-remove-btn');
    var myDropzoneLicenses = new Dropzone('#LincenseDiv', { // Make the whole body a dropzone
        url: $('#SaveFilesLicenses').val(),//"/target-url", // Set the url
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
    var removeBtn = $('#dz-remove-btn');
    var myDropzoneWarranty = new Dropzone('#WarrantyDiv', { // Make the whole body a dropzone
        url: $('#SaveFilesWarranty').val(),//"/target-url", // Set the url
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
        url: $('#SaveFilesMaintenance').val(),//"/target-url", // Set the url
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

//For Attachment in work order
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
    var previewNodeAttachment = document.querySelector("#dz-templateAttachment");
    previewNodeAttachment.id = "";
    var previewTemplateAttachment = previewNodeAttachment.parentNode.innerHTML;
    previewNodeAttachment.parentNode.removeChild(previewNodeAttachment);

    var uplodaBtnAttachment = $('#dz-upload-btnAttachment');
    var removeBtn = $('#dz-remove-btn');
    var myDropzoneAttachment = new Dropzone('#AttachmentDiv', { // Make the whole body a dropzone
        url: $('#SaveFilesAttachment').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplateAttachment,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previewsAttachment", // Define the container to display the previews
        clickable: ".fileinput-buttonAttachment" // Define the element that should be used as click trigger to select files.
    });


    myDropzoneAttachment.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtnAttachment.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzoneAttachment.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzoneAttachment.on("totaluploadprogress", function (progress) {
        $("#dz-total-progressAttachment .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzoneAttachment.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progressAttachment").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzoneAttachment.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progressAttachment").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtnAttachment.on('click', function () {
        //Upload all files
        myDropzoneAttachment.enqueueFiles(myDropzoneAttachment.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneAttachment.enqueueFiles(myDropzoneAttachment.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneAttachment.processQueue();



        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "Attachment" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzoneAttachment.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});

//For Asset in asset
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
    var previewNodeAsset = document.querySelector("#dz-templateAsset");
    previewNodeAsset.id = "";
    var previewTemplateAsset = previewNodeAsset.parentNode.innerHTML;
    previewNodeAsset.parentNode.removeChild(previewNodeAsset);

    var uplodaBtnAsset = $('#dz-upload-btnAsset');
    var removeBtn = $('#dz-remove-btn');
    var myDropzoneAsset = new Dropzone('#LincenseDiv', { // Make the whole body a dropzone
        url: $('#SaveFilesAsset').val(),//"/target-url", // Set the url
        thumbnailWidth: 50,
        thumbnailHeight: 50,
        parallelUploads: 20,
        previewTemplate: previewTemplateAsset,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#dz-previewsAsset", // Define the container to display the previews
        clickable: ".fileinput-buttonAsset" // Define the element that should be used as click trigger to select files.
    });


    myDropzoneAsset.on("addedfile", function (file) {
        // Hookup the button
        uplodaBtnAsset.prop('disabled', false);


        removeBtn.prop('disabled', false);

        // file.previewElement.querySelector(".start").onclick = function() { myDropzoneAsset.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzoneAsset.on("totaluploadprogress", function (progress) {
        $("#dz-total-progressAsset .progress-bar").css({ 'width': progress + "%" });
    });

    myDropzoneAsset.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#dz-total-progressAsset").style.opacity = "1";
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzoneAsset.on("queuecomplete", function (progress) {
        document.querySelector("#dz-total-progressAsset").style.opacity = "0";
    });


    // Setup the buttons for all transfers
    uplodaBtnAsset.on('click', function () {
        //Upload all files
        myDropzoneAsset.enqueueFiles(myDropzoneAsset.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneAsset.enqueueFiles(myDropzoneAsset.getFilesWithStatus(Dropzone.ADDED));
        myDropzoneAsset.processQueue();



        $.ajax({
            url: $("#test").val(),
            type: "GET",
            dataType: "JSON",
            data: { fType: "Asset" },
            success: function (data) {

            }
        });
    });

    removeBtn.on('click', function () {
        myDropzoneAsset.removeAllFiles(true);
        uplodaBtn.prop('disabled', true);
        removeBtn.prop('disabled', true);
    });

});