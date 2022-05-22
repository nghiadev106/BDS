$(document).ready(function() {
    
    var inputFile = $('input#file');
    var uploadURI = 'projects/ajax/projects/ajax_upload';
    var processBar = $('#progress-bar');

    $('input#file').change(function(event) {
        var filesToUpload = inputFile[0].files;

        if (filesToUpload.length > 0) {

            var formData = new FormData();

            for (var i = 0; i < filesToUpload.length ; i++) {
                var file = filesToUpload[i];
                formData.append('file[]', file, file.name);
            }


            $.ajax({
                url: uploadURI,
                type: 'post',
                data : formData,
                processData: false,
                contentType: false,
                success:  function (data)
                {
                	$('#list_album').show();
                    var json = JSON.parse(data);
                    $('.list-group').append(json.html);
                    $('.list-error').html(json.error);
                },
                xhr: function(){
                    var xhr = new XMLHttpRequest();
                    xhr.upload.addEventListener('progress', function(event){
                        if (event.lengthComputable) {
                            var percentComplete = Math.round((event.loaded / event.total)*100);
                            $('.progress').show();
                            processBar.css({width: percentComplete + "%"});
                            processBar.text(percentComplete + "%");
                        };
                    }, false);
                    return xhr;
                }
            });
        }
    });

    $(document).on('click', '.remove-file', function(){
        var me = $(this);
        $.ajax({
            url: uploadURI,
            type: 'post',
            data : {file_to_remove: me.attr('data-file'), delete:  me.attr('data-delete')},
            success:  function ()
            {
                me.closest('li').remove();
            }
        });
    });

    $(document).on('click', 'input[name=file]', function(){
        $('.progress').hide();
        processBar.css({width: "0%"});
        processBar.text("0%");
    });
});