import React from 'react';

interface TabHeaderProps {
    id: string,
    target: string,
    children: React.ReactNode;
}

const TabHeader: React.FC<TabHeaderProps> = ({ id, target: dataTab, children }) => {
    return (
        <li className='w-1/2' role="presentation">
            <button className="btn-nav-tab" id={id} data-tabs-target={`#${dataTab}`} type="button" role="tab" aria-controls={dataTab} aria-selected="false">{children}</button>
        </li>
    )
}

export default TabHeader;