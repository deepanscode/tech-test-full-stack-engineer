import React from 'react';

interface TabHeadersProps {
	target: string,
	children: React.ReactNode;
}

const TabHeaders: React.FC<TabHeadersProps> = ({ target: dataTansToggle, children }) => {
	return (
		<div className="p-4 w-full">
			<ul className="nav-tabs" data-tabs-toggle={`#${dataTansToggle}`} role="tablist">{children}</ul>
		</div>
	)
};

export default TabHeaders;