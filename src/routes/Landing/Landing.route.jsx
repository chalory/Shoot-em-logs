import React from "react";

import "./Landing.style.scss";

import posterSrc1 from "../../assets/poster-1.jpg";
import posterSrc2 from "../../assets/poster-2.jpg";

const Landing = () => {
    return (
        <section className="landing">
            <div className="heading-box">
                <div>
                    <span className="main">Shoot 'em</span>
                    <span className="sub">Logs</span>
                </div>
            </div>

            <div className="main-content">
                <div className="posters">
                    <img className="poster" src={posterSrc1} alt="Wanted Poster" />
                    <img className="poster" src={posterSrc2} alt="Wanted Poster" />
                </div>

                <div className="main-content__texts">
                    <h2>Lorem ipsum dolor sit amet.</h2>
                    <p>
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi, quos!
                        Obcaecati voluptatum, accusamus laborum sunt consequuntur recusandae
                        impedit. Perspiciatis atque neque ex obcaecati fuga. Doloribus!
                    </p>
                    <a href="#" className="start-shoot-btn">
                        Start Shooting!
                    </a>
                </div>
            </div>

            {/* <div className="box left">
                <h1>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla, voluptatum.</h1>
            </div>
            <div className="box right">
                <p>
                    Lorem ipsum, dolor sit amet consectetur adipisicing elit. Quisquam illum cumque
                    fuga assumenda eveniet dolorum.
                </p>
            </div> */}
        </section>
    );
};

export default Landing;
