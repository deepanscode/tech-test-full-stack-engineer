import React from 'react';

interface TabContentProps {
    id: string,
    source: string,
    children: React.ReactNode;
}

const TabContent: React.FC<TabContentProps> = ({ id, source, children }) => {
    return (
        <div className="hidden p-4 w-full" id={id} role="tabpanel" aria-labelledby={source}>
          {children}
        </div>
    )
}

export default TabContent;