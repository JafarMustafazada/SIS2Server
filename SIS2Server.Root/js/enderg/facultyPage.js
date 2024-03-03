
function fillFacultyTable() {
    let table = document.getElementById("faculty-table");
    var flag2 = false;
    
    getRequest(apiEPoints["faculty"], function (response) {
        let jsonArray1 = JSON.parse(response);
        
        for (let i = 0; i < jsonArray1.length; i++) {
            const element = jsonArray1[i];
            let subjects = "";

            getRequest(apiEPoints["faculty"] + "/" + element.id, function (response2) {
                flag2 = false;
                let jsonArray2 = JSON.parse(response2);

                for (let index = 0; index < jsonArray2.facultySemesters.length; index++) {
                    const semester = jsonArray2.facultySemesters[index];
                    subjects += "|semester - " + semester.semester + "\n";

                    for (let j = 0; j < semester.facultySubjects.length; j++) {
                        subjects += "\t" + semester.facultySubjects[j].name + ",\n";
                    }
                }

                let tables = `
                <tr>
                    <td>${element.id}</td>
                    <td>${element.name}</td>
                    <td>${subjects}</td>
                </tr>`;

                table.innerHTML += tables;
            });
        }
    });
}

fillFacultyTable();