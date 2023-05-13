'use client'

import 'flowbite';
import InvitedLead from './components/InvitedLead'
import AcceptedLead from './components/AcceptedLead'
import TabHeaders from './components/common/Tabs/TabHeaders';
import TabHeader from './components/common/Tabs/TabHeader';
import TabContents from './components/common/Tabs/TabContents';
import TabContent from './components/common/Tabs/TabContent';


export default function Home() {
	return (
		<main className="flex min-h-screen flex-col items-center p-24  bg-gray-50 dark:bg-gray-800">
			<TabHeaders target='leadsTabContent'>
				<TabHeader id="invited-tab" target='invited'>
					Invited
				</TabHeader>
				<TabHeader id="accepted-tab" target='accepted'>
					Accepted
				</TabHeader>
			</TabHeaders>
			<TabContents id='leadsTabContent'>
				<TabContent id="invited" source='invited-tab'>
					<InvitedLead/>
					<InvitedLead/>
					<InvitedLead/>
				</TabContent>
				<TabContent id="accepted" source='accepted-tab'>
					<AcceptedLead/>
				</TabContent>
				</TabContents>
		</main>
	)
}
