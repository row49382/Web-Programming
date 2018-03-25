$(document).ready(function() 
{
	$("#contact-form").submit(function(e) 
	{
		e.preventDefault();
        var url = "http://localhost:55439/api/values";
        $.ajax(url,
            {
                method: "POST",
                success: function (data)
                {
                    document.getElementById("error").innerHTML = "";
                    document.getElementById("result").innerHTML = data;
                },
                error: function (data)
                {
					document.getElementById("result").innerHTML = "";
					if (data.responseText !== null)
						document.getElementById("error").innerHTML = data.responseText;
					else
                        document.getElementById("error").innerHTML = JSON.stringify(data);
                },
                contentType: "application/json",
                data: JSON.stringify(
                    {
                        Address: document.getElementById("address").value
                    })
            })
		
	});
});