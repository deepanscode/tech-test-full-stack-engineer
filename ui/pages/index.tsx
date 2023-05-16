'use client'

import 'flowbite';
import {dehydrate, QueryClient} from "@tanstack/react-query";
import TabHeaders from "@/components/common/Tabs/TabHeaders";
import TabHeader from "@/components/common/Tabs/TabHeader";
import TabContents from "@/components/common/Tabs/TabContents";
import TabContent from "@/components/common/Tabs/TabContent";
import NewJob from "@/components/job/new_jobs/NewJob";
import AcceptedJob from "@/components/job/accepted_job/AcceptedJob";
import {fetchJobs, useJobs} from "@/hooks";
import {JobStatus} from "@/enums";
import {useState} from "react";
import NewJobsLayout from "@/components/job/new_jobs/NewJobsLayout";
import AcceptedJobsLayout from "@/components/job/accepted_job/AcceptedJobsLayout";

const Home = () => {


    return (
        <main className="page-content">
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
                    <NewJobsLayout/>
                </TabContent>
                <TabContent id="accepted" source='accepted-tab'>
                    <AcceptedJobsLayout/>
                </TabContent>
            </TabContents>
        </main>
    );
};

export default Home

