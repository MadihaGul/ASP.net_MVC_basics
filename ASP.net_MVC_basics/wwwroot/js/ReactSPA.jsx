
class PersonTable extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Peoplelist: [],
            Id: 0,
            IsModalOpen: false
        }
        this.refreshPeopleList = this.refreshPeopleList.bind(this);
     
    }
    componentDidMount() {
        this.getPeople()
    }
    
    getPeople = () => {
        fetch("/React/GetPeople").then(response => response.json()).
            then(data => {
                this.setState({ Peoplelist: data})
            })
    }

    sortAtoZ() {
        this.setState(this.state.Peoplelist.sort(function (a, b) {
            return a.name.localeCompare(b.name)
        } ) )
    }
    sortZtoA = () =>{
        this.setState(this.state.Peoplelist.sort(function (a, b) {
            return b.name.localeCompare(a.name)
        }))
    }

    sortUndo() {
        this.getPeople()
    }
    refreshPeopleList=() =>{

        this.setState({
            Id: 0,
            IsModalOpen: false
        })
        
         this.getPeople()       
        
    }
    
    render() {
        const row = this.state.Peoplelist.map((list, i) => {
    
            return (
                <tr key={i}>

                    <td >{i + 1}</td>
                    <td>{list.name}</td>
                    <td>{list.phone}</td>
                    <td> <button type="button" data-toggle="modal" data-target="#detailPersonModal"
                        onClick={() => { this.setState({ IsModalOpen: true, Id: list.personId }) }}> Detail</button> </td>
                    
                </tr>
            )

        })

        return (
            <div className="PersonTable">
                <div>
                    <div className="ml-2 mb-2 mt-4">
                    <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#createPeopleModal" >Create</button>
                    </div>
                    <div>
                        <div className="float-right mr-2 mb-2 "><button onClick={() => this.refreshPeopleList()}>Reload People</button>                   

                        </div>
                        <h4>PeopleList</h4>
                    </div>
                    <hr />
                    <h5>Sort</h5>
                    <button onClick={() => this.sortAtoZ()}>By Name(AtoZ)</button>
                    &nbsp;|&nbsp;
                    <button onClick={() => this.sortZtoA()}>By Name(ZtoA)</button>
                    &nbsp;|&nbsp;
                    <button onClick={() => this.sortUndo()}>None</button>
                    
                </div>
                <div>
                    <table id="Peoplelist" className="table table-active table-hover table-primary">
                        <TableHeaderPeople />
                        <tbody>{ row}</tbody>
                    </table>
                    <CreatePeople refreshPeopleList={() => { this.getPeople() }} />
                    {this.state.IsModalOpen == true ? < PersonDetails refreshPeopleList={() => { this.refreshPeopleList() }} id={this.state.Id} CloseModal={() => {  this.setState({ IsModalOpen: false }) }} /> : null}

                </div>
            </div>

            );
    }
}

//==========================================================================================================

//==========================================================================================================

class TableHeaderPeople extends React.Component {
  
    render() {
         return (          
                <thead>
                    <tr>
                         <th >#</th>
                         <th >Name</th>
                         <th >Phone</th>
                      
                         <th >Detail</th>
                      
                    </tr>
                 </thead>
         
        );
    }
}

//==========================================================================================================
//==========================================================================================================
//==========================================================================================================

class CreatePeople extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listCountry: [],
            listCity: [],           
            Name: '',
            Phone: '',            
            Country: 0,
            City: 0,

            formErrors: { Name: '', Phone: '', Country:'', City: ''},
            NameValid: false,
            PhoneValid: false,
            CountryValid: false,
            CityValid: false,
            formValid: false
        };
       
        this.handleCountryChange = this.handleCountryChange.bind(this);
     /*   this.handleCityChange = this.handleCityChange.bind(this);*/
        this.onchange = this.onchange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleCountryChange(e) {
        e.preventDefault();
        const valid = this.validateField(e.target.name, e.target.value)
        this.setState({ Country: e.target.value });
        if (valid)
        {
        const data = new FormData();
        data.append('countryId', e.target.value);
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/React/GetCities', true);

        xhr.send(data);

        xhr.onload = function () {
            if (xhr.status === 200) {

                this.setState({
                    listCity: JSON.parse(xhr.response), CityValid: false,formValid: false, City:0
                   });
            } else {
                consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
            }
            }.bind(this)

           
        }

    }
    //handleCityChange(e) {
     
    //    this.setState({ City: e.target.value },
    //        () => { this.validateField(e.target.name, e.target.value) });
    //}

    handleSubmit = (e) => {
        e.preventDefault();
       
            const data = new FormData();
            data.append('Name', this.state.Name.trim());
            data.append('Phone', this.state.Phone.trim());
            data.append('CityId', this.state.City);
            const xhr = new XMLHttpRequest();
            xhr.open('post', '/React/CreatePerson', true);

            xhr.send(data);
            xhr.onload = function () {

                if (xhr.status === 200) {
                    this.refreshCreateModal()
                    alert(xhr.response);
                } else {
                    consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
                }
            }.bind(this);
        
    }

    refreshCreateModal() {
     
        this.setState({
            Name: '',
            Phone: '',
            Country: 0,
            City: 0,
            formErrors: { Name: '', Phone: '', Country: '', City: '' },
            NameValid: false,
            PhoneValid: false,
            CountryValid: false,
            CityValid: false,
            formValid: false          
            
        })
        this.props.refreshPeopleList()
}

    onchange(e) {
        e.preventDefault();
        const valid = this.validateField(e.target.name, e.target.value)

        this.setState(
            {
                [e.target.name]: e.target.value
            })
       
    }
 
    validateField(fieldName, value) {
        let fieldValidationErrors = this.state.formErrors;
        let NameValid = this.state.NameValid;
        let PhoneValid = this.state.PhoneValid;
        let CountryValid = this.state.CountryValid;
        let CityValid = this.state.CityValid;
   

        switch (fieldName) {
            case 'Name':
                if (value.trim() === '') {
                    NameValid = false;
                    fieldValidationErrors.Name = NameValid ? '' : ' is required';
                }
                else if (/[^a-zA-Z -]/.test(value)) {
                    NameValid = false;
                    fieldValidationErrors.Name = NameValid ? '' : ' Invalid characters';
                }
                else if (value.trim().length <2 || value.trim().length > 100) {
                    NameValid = false;
                    fieldValidationErrors.Name = NameValid ? '' : ' length must be between 2-100 characters';
                }
                else {
                    NameValid = true;
                    fieldValidationErrors.Name = NameValid ? '' : 'Error! Contact Admin';
                    
                }
                break;

            case 'Phone':
                var pattern = new RegExp(/^[+ 0-9\b -]+$/);
                if (value.trim() === '') {
                    PhoneValid = false;
                    fieldValidationErrors.Phone = PhoneValid ? '' : ' is required';
                }
                else if (value.trim().length < 9 || value.trim().length > 13) {
                    PhoneValid = false;
                    fieldValidationErrors.Phone = PhoneValid ? '' : ' Invalid length';
                }
                else if (!pattern.test(value.trim())) {

                    PhoneValid = false;
                    fieldValidationErrors.Phone = PhoneValid ? '' : 'Enter only numbers';
                }
                else {
                    PhoneValid = true;
                    fieldValidationErrors.Phone = PhoneValid ? '' : 'Error! Contact Admin';
                }
                break;

            case 'Country':
                if (value == 0) {
                    CountryValid = false;
                    fieldValidationErrors.Country = CountryValid ? '' : ' is required';
                }
                else
                {
                    CountryValid = true;
                    fieldValidationErrors.Country = CountryValid ? '' : ' Error! Contact Admin';
                }
                
                break;
            case 'City':
                if (value == 0) {
                    CountryValid = false;
                    fieldValidationErrors.Country = CountryValid ? '' : ' is required';
                }
                else {
                    CityValid = true;
                    fieldValidationErrors.City = CityValid ? '' : ' Error! Contact Admin';
                }
                
                break;
            default:
                break;
        }
        this.setState({
            formErrors: fieldValidationErrors,
            NameValid: NameValid,
            PhoneValid: PhoneValid,
            CountryValid: CountryValid,
            CityValid: CityValid
        }, this.validateForm);


        if (fieldName == 'Name') { return NameValid }
        else if (fieldName == 'Phone') { return PhoneValid }
        else if (fieldName == 'Country') { return CountryValid }
        else if (fieldName == 'City') { return CityValid }
    }

    validateForm() {
        this.setState({ formValid: this.state.NameValid && this.state.PhoneValid && this.state.CountryValid && this.state.CityValid });
    }

    componentDidMount() {
        this.getCountries()
        this.getInitialCites()
       
    }
    getCountries = () => {
        fetch("/React/GetCountries").then(response => response.json()).
            then(data => {
                this.setState({ listCountry: data })
            })
    }
    getInitialCites = () => {
        const res = fetch("/React/GetInitialCites").then(response => response.json()).
            then(data => {
                this.setState({ listCity: data })
            })
    }
 
    errorClass(error) {
        return (error.length === 0 ? '' : 'Error');
    }
    render() {
        const FormErrors = ({ formErrors }) =>
            <div className='formErrors'>
                {Object.keys(formErrors).map((fieldName, i) => {
                    if (formErrors[fieldName].length > 0) {
                        return (
                            <p key={i}>{fieldName} {formErrors[fieldName]}</p>
                        )
                    } else {
                        return '';
                    }
                })}
            </div>
        return (

<div className="modal fade" id="createPeopleModal" tabIndex="-1" role="dialog" aria-hidden="true">
  <div className="modal-dialog" role="document">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" >Create People</h5>
                            <button type="button" onClick={() => this.refreshCreateModal() } className="close" data-dismiss="modal" aria-label="Close">
             <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <div className="modal-body">
                <div className="panel panel-default">
                    <FormErrors formErrors={this.state.formErrors} />
                </div>

          <form >
                                <div className="form-group" >
                                    <label htmlFor="txtname" className="col-form-label">Name:</label>*
                                    <input type="text" className="form-control" name="Name" value={this.state.Name} id="txtname" onChange={(event) => this.onchange(event)} />
                              
                                  
          </div>
                                <div className="form-group ">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone:</label>*
                                    <input type="text" className="form-control" name="Phone" value={this.state.Phone} id="txtPhone" onChange={(event) => this.onchange(event)} />
                                </div>
                                <div className="form-group ">
                                    <label htmlFor="txtCountry" >Country:</label>*
                                    <select id="txtCountry" name="Country" value={this.state.Country} onChange={(event) => this.handleCountryChange(event)} >
                                            {this.state.listCountry.map((lstCountry,i) => (
                                                <option key={i} value={lstCountry.countryId}>{lstCountry.countryName}</option>
                                                ))}
                                    </select>
                                       
                                    
                                </div>
                            
                                <div className="form-group ">
                                    <label htmlFor="txtCity" className="col-form-label">City:</label>*
                                    <select disabled={!this.state.CountryValid} id="txtCity" name="City" value={this.state.City} onChange={(event) => this.onchange(event)} >
                                        {
                                            this.state.listCity.map((lstCity, i) => (
                                            <option key={i} value={lstCity.cityId}>{lstCity.cityName}</option>
                                        ))}
                                    </select>
                                </div>
                           
                                <button className="btn btn-primary" disabled={!this.state.formValid} type="submit" onClick={this.handleSubmit} >Save</button>

        </form>
      </div>
    
    </div>
  </div>
</div>
            );
    }
}
//==========================================================================================================
//==========================================================================================================

//==========================================================================================================
//==========================================================================================================

class PersonDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listLanguage: [],
            Language: 0,
            Id:0,
            Name: '',
            Phone: '',
            Country: '',
            City: '',
            Languages: '',

            formErrors: { Language: '' },
            LanguageValid: false
        }
        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.refreshDetailModal = this.refreshDetailModal.bind(this);
        this.handleAddLanguage = this.handleAddLanguage.bind(this);
        this.postDeleteDisable = this.postDeleteDisable.bind(this);
    }

    handleLanguageChange(e) {
   
        const valid = this.validateField(e.target.name, e.target.value)
        this.setState({ Language: e.target.value });
    }

    handleDelete = (e) => {
        e.preventDefault();

        fetch("/React/DeletePerson?personId=" + this.state.Id).then(response => response.json()).
            then(data => {
                alert(data);

                this.setState({
                    Language: 0,
                    Id: 0,
                    Name: '',
                    Phone: '',
                    Country: '',
                    City: '',
                    Languages: ''
                })
                this.postDeleteDisable()                
                
            })

    }

    handleAddLanguage = (e) => {
        e.preventDefault();

        const data = new FormData();
        
        data.append('PersonId', this.state.Id);
        data.append('LanguageId', this.state.Language);
     
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/React/AddLanguage', true);

        xhr.send(data);
        xhr.onload = function () {

            if (xhr.status === 200) {
                this.getPersonDetail();
                alert(xhr.response);
            } else {
                consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
            }
        }.bind(this);

    }

    validateField(fieldName, value) {
        let fieldValidationErrors = this.state.formErrors;
        let LanguageValid = this.state.LanguageValid;
    


        switch (fieldName) {
        
            case 'Language':
                if (value == 0) {
                    LanguageValid = false;
                    fieldValidationErrors.Language = LanguageValid ? '' : ' is required';
                }
                else {
                    LanguageValid = true;
                    fieldValidationErrors.Language = LanguageValid ? '' : ' Error! Contact Admin';
                }
                break;
            default:
                break;
        }
        this.setState({
            formErrors: fieldValidationErrors,

            LanguageValid: LanguageValid
        });


        if (fieldName == 'Language') { return LanguageValid }
    }

    postDeleteDisable() {
        document.getElementById('btnDelete').disabled = true        
        document.getElementById('txtlistLanguage').disabled = true
        this.setState({ LanguageValid: false });
    }

    refreshDetailModal() {

        this.setState({
        
            Id:0,
            Name: '',
            Phone: '',
            Country: '',
            City: '',
            Languages: '',
            Language: 0
        })

        this.props.refreshPeopleList()
        
    }

  
    componentDidMount() {
        if (this.props.id > 0) {
            this.getPersonDetail()
            this.getLanguages()
        }
        
    }
    getPersonDetail = () => {
        fetch("/React/GetPersonDetails?personId=" + this.props.id).then(response => response.json()).
            then(data => {
                this.setState({
                    Id: data.personId,
                    Name: data.name,
                    Phone: data.phone,
                    Country: data.city,
                    City: data.country,
                    Languages: data.speakLanguages
                })
            })


    }
    getLanguages = () => {
        fetch("/React/GetLanguages").then(response => response.json()).
            then(data => {
                this.setState({ listLanguage: data })
            })
    }


    render() {

        return (

            <div className="modal fade" id="detailPersonModal" tabIndex="-1" role="dialog" aria-hidden="true">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" >Details</h5>
                            <button type="button" onClick={() => this.refreshDetailModal()} className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true"  >&times;</span>
                            </button>
                       
                        </div>
                        <div className="modal-body">
                            <form >
                                <div className="form-group">
                                    <label htmlFor="txtname" className="col-form-label">Name:</label>
                                    <input type="text" className="form-control" name="Name" value={this.state.Name} id="txtname" disabled />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone:</label>
                                    <input type="text" className="form-control" name="Phone" value={this.state.Phone} id="txtPhone" disabled />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtCity" className="col-form-label">City:</label>
                                    <input type="text" className="form-control" name="City" value={this.state.City} id="txtCity" disabled />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtCountry" className="col-form-label">Country:</label>
                                    <input type="text" className="form-control" name="Country" value={this.state.Country} id="txtCountry" disabled />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtLanguages" className="col-form-label">Languages:</label>
                                    <input type="text" className="form-control" name="Languages" value={this.state.Languages} id="txtLanguages" disabled />
                                </div>

                                <div className="form-group">
                                    <label htmlFor="txtlistLanguage" className="col-form-label">Language:</label>
                                    <select id="txtlistLanguage" value={this.state.Language} name="Language" onChange={this.handleLanguageChange} >
                                        {
                                            this.state.listLanguage.map((lstLanguage, i) => (
                                                <option key={i} value={lstLanguage.languageId}>{lstLanguage.languageName}</option>
                                            ))}
                                    </select>
                                    <button id="btnAddLanguage" className="btn btn-primary" type="submit" disabled={!this.state.LanguageValid} onClick={this.handleAddLanguage} >Add</button>
                                </div>

                                
                              
                                <button id ="btnDelete" className="btn btn-danger" type="submit" onClick={this.handleDelete}  >Delete Person</button>

                            </form>
                        </div>

                    </div>
                </div>
            </div>
        );
    }
}

    



//==========================================================================================================

ReactDOM.render(<PersonTable />, document.getElementById('content'));
