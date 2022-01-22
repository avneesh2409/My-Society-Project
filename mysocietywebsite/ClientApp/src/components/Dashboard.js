import React from 'react'
import './styles/style.css'

const Dashboard = (props) => {
    return (
        <React.Fragment>
            <div className="section">

            
           
                <div className="container">

                    <div className="row">

                        <div className="col-md-6">
                            <div className="section-header">
                                <h2>Welcome to Higher Secondary School</h2>
                                <p className="lead">We are usually known as "EduNet" or "EdNet" by our schools. For them, we are the "school website company" – in actuality – we are a software company. </p>
                            </div>

                            <div className="feature">
                                <i className="feature-icon fa fa-flask"></i>
                                <div className="feature-content">
                                    <h4>Online Courses </h4>
                                    <p>Their responsibility is to custom design the website of each one of our schools to make sure it reflects their unique culture; all the while, ensuring it is easy to use and navigate. </p>
                                </div>
                            </div>

                            <div className="feature">
                                <i className="feature-icon fa fa-users"></i>

                                <div className="feature-content">
                                    <h4>Expert Teachers</h4>
                                    <p>Whether it's to create a custom banner using Photoshop, or answer a simple question from a teacher, it's their responsibility. We call it technical support, but in reality, it is a team of highly skilled web developers ready to help</p>
                                </div>
                            </div>

                            <div className="feature">
                                <i className="feature-icon fa fa-comments"></i>
                                <div className="feature-content">
                                    <h4>Community</h4>
                                    <p>Ceteros fuisset mei no, soleat epicurei adipiscing ne vis. Et his suas veniam nominati.</p>
                                </div>
                            </div>


                        </div>

                    </div>


                </div>

            </div>

            <div id="courses" className="section">


                <div className="container">


                    <div className="row">
                        <div className="section-header text-center">
                            <h2>Explore Courses</h2>
                            <p className="lead">Libris vivendo eloquentiam ex ius, nec id splendide abhorreant.</p>
                        </div>
                    </div>



                    <div id="courses-wrapper">


                        <div className="row">


                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course01.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">Beginner to Pro in Excel: Financial Modeling and Valuation</a>
                                    <div className="course-details">
                                        <span className="course-category">Business</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>



                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course02.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">Introduction to CSS </a>
                                    <div className="course-details">
                                        <span className="course-category">Web Design</span>
                                        <span className="course-price course-premium">Premium</span>
                                    </div>
                                </div>
                            </div>



                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course03.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">The Ultimate Drawing Course | From Beginner To Advanced</a>
                                    <div className="course-details">
                                        <span className="course-category">Drawing</span>
                                        <span className="course-price course-premium">Premium</span>
                                    </div>
                                </div>
                            </div>


                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course04.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">The Complete Web Development Course</a>
                                    <div className="course-details">
                                        <span className="course-category">Web Development</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>


                        </div>



                        <div className="row">


                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course05.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">PHP Tips, Tricks, and Techniques</a>
                                    <div className="course-details">
                                        <span className="course-category">Web Development</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>



                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course06.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">All You Need To Know About Web Design</a>
                                    <div className="course-details">
                                        <span className="course-category">Web Design</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>



                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course07.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">How to Get Started in Photography</a>
                                    <div className="course-details">
                                        <span className="course-category">Photography</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>




                            <div className="col-md-3 col-sm-6 col-xs-6">
                                <div className="course">
                                    <a href="#" className="course-img">
                                        <img src="./img/course08.jpg" alt="" />
                                        <i className="course-link-icon fa fa-link"></i>
                                    </a>
                                    <a className="course-title" href="#">Typography From A to Z</a>
                                    <div className="course-details">
                                        <span className="course-category">Typography</span>
                                        <span className="course-price course-free">Free</span>
                                    </div>
                                </div>
                            </div>


                        </div>


                    </div>


                    <div className="row">
                        <div className="center-btn">
                            <a className="main-button icon-button" href="#">More Courses</a>
                        </div>
                    </div>

                </div>


            </div>

        </React.Fragment>
    )
}

export default Dashboard

