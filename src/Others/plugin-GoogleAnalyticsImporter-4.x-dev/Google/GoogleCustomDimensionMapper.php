<?php
/**
 * Piwik - free/libre analytics platform
 *
 * @link http://piwik.org
 * @license http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
 */

namespace Piwik\Plugins\GoogleAnalyticsImporter\Google;


use Piwik\Plugins\CustomDimensions\Dimension\Name;
use Piwik\Plugins\GoogleAnalyticsImporter\CannotImportCustomDimensionException;

class GoogleCustomDimensionMapper
{

    public function map(\Google_Service_Analytics_CustomDimension $gaCustomDimension)
    {
        $result = [
            'name' => $gaCustomDimension->getName(),
            'extractions' => [],
            'case_sensitive' => true,
            'scope' => $this->mapScope($gaCustomDimension),
            'active' => $gaCustomDimension->getActive(),
        ];

        $blockedChars = Name::getBlockedCharacters();
        $result['name'] = str_replace($blockedChars, '', $result['name']);

        return $result;
    }

    private function mapScope(\Google_Service_Analytics_CustomDimension $gaCustomDimension)
    {
        $scope = $gaCustomDimension->getScope();
        switch (strtolower($scope)) {
            case 'hit':
                return 'action';
            case 'session':
                return 'visit';
            default:
                throw new CannotImportCustomDimensionException($gaCustomDimension, 'unsupported scope, "' . $scope . '"');
        }
    }
}