//$("#dateOfBirth").datepicker();

    $(document).ready(function () {
        $('input[type=datetime]').datepicker({
            dateFormat: "dd/mm/yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-60:+0" 
        });
        //$("#city").on("change", function {
        //    $("#city").val($(this).text());
        //});
    });

function readFile() {

    if (this.files && this.files[0]) {
        const oFile = document.getElementById("file").files[0];
    

        if (oFile.size > 2097152) // 2 MiB for bytes.
        {
            alert("File size must under 2MiB!");
            return;
        }
        var FR = new FileReader();

        FR.addEventListener("load", function (e) {
            document.getElementById("Image").src = e.target.result;
            document.getElementById("file").src = e.target.result;
            
          
        });

        FR.readAsDataURL(this.files[0]);
    }

}

document.getElementById("file").addEventListener("change", readFile);


