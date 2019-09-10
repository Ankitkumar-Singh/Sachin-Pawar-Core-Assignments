$(document).ready(function ()
{    
    $('#schoolNameCheck').hide();
    $('#addressCheck').hide();
    $('#courseCheck').hide();

    var schoolNameError = true;
    var addressError = true;
    var courseError = true;

    //Onclick event on Register button
    $('#btnReg').click(function ()
    {
        schoolNameError = true;
        addressError = true;
        courseError = true;

        SchoolNameCheck();
        AddressCheck();
        CheckCourses();

        if ((schoolNameError == true) && (addressError == true) && (courseError == true))
        {
            return true;
        }
        else
        {
            return false;
        }
    });
    
    //School name textbox validation
    $('#txtSchoolName').keyup(function ()
    {
        SchoolNameCheck();
    });

    function SchoolNameCheck()
    {
        var username = $('#txtSchoolName').val();
        if (username == '')
        {
            $('#schoolNameCheck').show();
            $('#schoolNameCheck').html("Please enter school name");
            $('#schoolNameCheck').focus();
            $('#schoolNameCheck').css("color", "red");
            schoolNameError = false;
            return false;
        }
        else
        {
            $('#schoolNameCheck').hide();
        }
    }    

    //Address textarea validation
    $('#txtAddress').keyup(function ()
    {
        AddressCheck();
    });

    function AddressCheck()
    {
        var Address = $('#txtAddress').val();
        if (Address == '') {
            $('#addressCheck').show();
            $('#addressCheck').html("Please enter address");
            $('#addressCheck').focus();
            $('#addressCheck').css("color", "red");
            addressError = false;
            return false;
        }
        else
        {
            $('#addressCheck').hide();
        }               
    }    

    //Courses CheckBoxes Validations with change events.
    $(":checkbox").click(function ()
    {
        CheckCourses();
    });

    function CheckCourses()
    {
        var a = 0;
        $(":checkbox").each(function ()
        {
            if (this.checked)
            {
                $('#courseCheck').hide();
                a = a + 1;
            }
        });
        if (a == 0)
        {
            $('#courseCheck').show();
            $('#courseCheck').html("Please select course");
            $('#courseCheck').focus();
            $('#courseCheck').css("color", "red");
            //$("span[id$='Label1']").text('Please select Any Course');
            courseError = false;
            return false;
        }
        else
        {
            $('#courseCheck').hide();
        }
    }
});