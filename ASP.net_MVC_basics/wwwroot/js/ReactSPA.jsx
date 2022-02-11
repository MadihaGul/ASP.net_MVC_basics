
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
            City: 0
        };
       
        this.handleCountryChange = this.handleCountryChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.onchange = this.onchange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleCountryChange(e) {
       
    
        this.setState({ Country: e.target.value });

        const data = new FormData();   
        data.append('countryId', e.target.value);
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/React/GetCities', true);

        xhr.send(data);

        xhr.onload = function () {
            if (xhr.status === 200) {
               
                this.setState({ listCity: JSON.parse(xhr.response) });
            } else {
                consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
            }
        }.bind(this)
    }

    handleCityChange(e) {
     
        this.setState({ City: e.target.value });
    }

   
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
            City: 0
            
        })
        this.props.refreshPeopleList()
}

    onchange = (e) => {
        this.setState({
                [e.target.name]: e.target.value
        })       
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
 
  
    render() {

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
                            <form >
          <div className="form-group">
               <label htmlFor="txtname" className="col-form-label">Name:</label>
               <input type="text" className="form-control" name="Name" value={this.state.Name} id="txtname" onChange={this.onchange} />
                              
                                  
          </div>
          <div className="form-group">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone:</label>
                                    <input type="text" className="form-control" name="Phone" value={this.state.Phone} id="txtPhone" onChange={this.onchange}/>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtCountry" >Country:</label>                                       
                                    <select id="txtCountry" value={this.state.Country} onChange={this.handleCountryChange} >
                                            {this.state.listCountry.map((lstCountry,i) => (
                                                <option key={i} value={lstCountry.countryId}>{lstCountry.countryName}</option>
                                                ))}
                                            </select>
                                       
                                    
                                </div>
                            
                                <div className="form-group">
                                    <label htmlFor="txtCity" className="col-form-label">City:</label>
                                    <select id="txtCity" value={this.state.City} onChange={this.handleCityChange} >
                                        {
                                            this.state.listCity.map((lstCity, i) => (
                                            <option key={i} value={lstCity.cityId}>{lstCity.cityName}</option>
                                        ))}
                                    </select>
                                </div>
                           
                            <button className="btn btn-primary" type="submit" onClick={this.handleSubmit} >Save</button>

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
            Languages: ''
           
        }
        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.refreshDetailModal = this.refreshDetailModal.bind(this);
        this.handleAddLanguage = this.handleAddLanguage.bind(this);
        this.postDeleteDisable = this.postDeleteDisable.bind(this);
    }

    handleLanguageChange(e) {

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
    
    postDeleteDisable() {
        document.getElementById('btnDelete').disabled = true
        document.getElementById('btnAddLanguage').disabled = true
        document.getElementById('txtlistLanguage').disabled = true
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
                                    <select id="txtlistLanguage" value={this.state.Language} onChange={this.handleLanguageChange} >
                                        {
                                            this.state.listLanguage.map((lstLanguage, i) => (
                                                <option key={i} value={lstLanguage.languageId}>{lstLanguage.languageName}</option>
                                            ))}
                                    </select>
                                    <button id="btnAddLanguage"className="btn btn-primary" type="submit" onClick={this.handleAddLanguage} >Add</button>
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
