import React from 'react'
/*import './styles/style.css'*/

const Contact = (props) => {
    return (
        <React.Fragment>
        

            <div id="contact" className="section">

                <div className="container">

                    <div className="row">
                   
                        <div className="col-md-6">
                            <div className="contact-form">
                                <h4>Send A Message</h4>
                                <form>
                                    <input className="input" type="text" name="name" placeholder="Name" />
                                    <input className="input" type="email" name="email" placeholder="Email" />
                                    <input className="input" type="text" name="subject" placeholder="Subject" />
                                    <textarea className="input" name="message" placeholder="Enter your Message"></textarea>
                                    <button className="main-button icon-button pull-right">Send Message</button>
                                </form>
                            </div>
                        </div>

                        <div className="col-md-5 col-md-offset-1">
                            <h4>Contact Information</h4>
                            <ul className="contact-details">
                                <li><i className="fa fa-envelope"></i>CientmailId@gmail.com</li>
                                <li><i className="fa fa-phone"></i>122-547-223-45</li>
                                <li><i className="fa fa-map-marker"></i>Durgapur West Bengal</li>
                            </ul>
                        </div>

                    </div>

                </div>

            </div>

        </React.Fragment>
    )
}

export default Contact