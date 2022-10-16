import React from "react";

import "./Header.style.scss";

const Header = () => {
    return (
        <header>
            <h1>
                <a href="#">Logo</a>
            </h1>
            <nav>
                <ul>
                    <li>
                        <a href="#">Play</a>
                    </li>
                    <li>
                        <a href="#">About</a>
                    </li>
                    <li>
                        <a href="#">Contact</a>
                    </li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;
