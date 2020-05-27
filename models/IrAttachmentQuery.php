<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[IrAttachment]].
 *
 * @see IrAttachment
 */
class IrAttachmentQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return IrAttachment[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return IrAttachment|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
